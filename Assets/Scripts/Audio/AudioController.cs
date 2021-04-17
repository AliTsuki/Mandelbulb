using DSPLib;

using System;
using System.Numerics;
using System.Threading;

using UnityEngine;


// Code borrowed from:
// https://github.com/jesse-scam/algorithmic-beat-mapping-unity
// https://medium.com/giant-scam/algorithmic-beat-mapping-in-unity-real-time-audio-analysis-using-the-unity-api-6e9595823ce4
// https://medium.com/giant-scam/algorithmic-beat-mapping-in-unity-preprocessed-audio-analysis-d41c339c135a
/// <summary>
/// Controls the audio components of the raymarcher.
/// </summary>
public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    private float[] realTimeSpectrum;
    private SpectralFluxAnalyzer realTimeSpectralFluxAnalyzer;
    private PlotController realTimePlotController;

    private int numChannels;
    private int numTotalSamples;
    private int sampleRate;
    private float clipLength;
    private float[] multiChannelSamples;
    private SpectralFluxAnalyzer preProcessedSpectralFluxAnalyzer;
    private PlotController preProcessedPlotController;

    public bool realTimeSamples = false;
    public bool preProcessSamples = true;


    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        // Process audio as it plays
        if(this.realTimeSamples)
        {
            this.realTimeSpectrum = new float[1024];
            this.realTimeSpectralFluxAnalyzer = new SpectralFluxAnalyzer();
            this.realTimePlotController = GameObject.Find("RealtimePlot").GetComponent<PlotController>();
            this.sampleRate = AudioSettings.outputSampleRate;
        }
        // Preprocess entire audio file upfront
        if(this.preProcessSamples)
        {
            this.preProcessedSpectralFluxAnalyzer = new SpectralFluxAnalyzer();
            this.preProcessedPlotController = GameObject.Find("PreprocessedPlot").GetComponent<PlotController>();
            // Need all audio samples.  If in stereo, samples will return with left and right channels interweaved
            // [L,R,L,R,L,R]
            this.multiChannelSamples = new float[this.audioSource.clip.samples * this.audioSource.clip.channels];
            this.numChannels = this.audioSource.clip.channels;
            this.numTotalSamples = this.audioSource.clip.samples;
            this.clipLength = this.audioSource.clip.length;
            // We are not evaluating the audio as it is being played by Unity, so we need the clip's sampling rate
            this.sampleRate = this.audioSource.clip.frequency;
            this.audioSource.clip.GetData(this.multiChannelSamples, 0);
            Debug.Log("GetData done");
            Thread bgThread = new Thread(this.GetFullSpectrumThreaded);
            Debug.Log("Starting Background Thread");
            bgThread.Start();
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // Real-time
        if(this.realTimeSamples)
        {
            this.audioSource.GetSpectrumData(this.realTimeSpectrum, 0, FFTWindow.BlackmanHarris);
            this.realTimeSpectralFluxAnalyzer.AnalyzeSpectrum(this.realTimeSpectrum, this.audioSource.time);
            this.realTimePlotController.UpdatePlot(this.realTimeSpectralFluxAnalyzer.spectralFluxSamples);
        }
        // Preprocessed
        if(this.preProcessSamples)
        {
            int indexToPlot = this.GetIndexFromTime(this.audioSource.time) / 1024;
            this.preProcessedPlotController.UpdatePlot(this.preProcessedSpectralFluxAnalyzer.spectralFluxSamples, indexToPlot);
        }
    }

    /// <summary>
    /// Gets the index from the given time.
    /// </summary>
    /// <param name="curTime">The time.</param>
    /// <returns>Returns the index.</returns>
    public int GetIndexFromTime(float curTime)
    {
        float lengthPerSample = this.clipLength / (float)this.numTotalSamples;
        return Mathf.FloorToInt(curTime / lengthPerSample);
    }

    /// <summary>
    /// Gets the time from the given index.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>Returns the time.</returns>
    public float GetTimeFromIndex(int index)
    {
        return 1f / (float)this.sampleRate * index;
    }

    /// <summary>
    /// Gets the full spectrum flux.
    /// </summary>
    public void GetFullSpectrumThreaded()
    {
        try
        {
            // We only need to retain the samples for combined channels over the time domain
            float[] preProcessedSamples = new float[this.numTotalSamples];
            int numProcessed = 0;
            float combinedChannelAverage = 0f;
            for(int i = 0; i < this.multiChannelSamples.Length; i++)
            {
                combinedChannelAverage += this.multiChannelSamples[i];
                // Each time we have processed all channels samples for a point in time, we will store the average of the channels combined
                if((i + 1) % this.numChannels == 0)
                {
                    preProcessedSamples[numProcessed] = combinedChannelAverage / this.numChannels;
                    numProcessed++;
                    combinedChannelAverage = 0f;
                }
            }
            Debug.Log("Combine Channels done");
            Debug.Log(preProcessedSamples.Length);
            // Once we have our audio sample data prepared, we can execute an FFT to return the spectrum data over the time domain
            int spectrumSampleSize = 1024;
            int iterations = preProcessedSamples.Length / spectrumSampleSize;
            FFT fft = new FFT();
            fft.Initialize((uint)spectrumSampleSize);
            Debug.Log(string.Format("Processing {0} time domain samples for FFT", iterations));
            double[] sampleChunk = new double[spectrumSampleSize];
            for(int i = 0; i < iterations; i++)
            {
                // Grab the current 1024 chunk of audio sample data
                Array.Copy(preProcessedSamples, i * spectrumSampleSize, sampleChunk, 0, spectrumSampleSize);
                // Apply our chosen FFT Window
                double[] windowCoefs = DSP.Window.Coefficients(DSP.Window.Type.Hanning, (uint)spectrumSampleSize);
                double[] scaledSpectrumChunk = DSP.Math.Multiply(sampleChunk, windowCoefs);
                double scaleFactor = DSP.Window.ScaleFactor.Signal(windowCoefs);
                // Perform the FFT and convert output (complex numbers) to Magnitude
                Complex[] fftSpectrum = fft.Execute(scaledSpectrumChunk);
                double[] scaledFFTSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(fftSpectrum);
                scaledFFTSpectrum = DSP.Math.Multiply(scaledFFTSpectrum, scaleFactor);
                // These 1024 magnitude values correspond (roughly) to a single point in the audio timeline
                float curSongTime = this.GetTimeFromIndex(i) * spectrumSampleSize;
                // Send our magnitude data off to our Spectral Flux Analyzer to be analyzed for peaks
                this.preProcessedSpectralFluxAnalyzer.AnalyzeSpectrum(Array.ConvertAll(scaledFFTSpectrum, x => (float)x), curSongTime);
            }
            Debug.Log("Spectrum Analysis done");
            Debug.Log("Background Thread Completed");
        }
        catch(Exception e)
        {
            // Catch exceptions here since the background thread won't always surface the exception to the main thread
            Debug.Log(e.ToString());
        }
    }
}
