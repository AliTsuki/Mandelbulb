using System.Collections.Generic;

using UnityEngine;


/// <summary>
/// Contains information about spectral flux.
/// </summary>
public class SpectralFluxInfo
{
    public float time;
    public float spectralFlux;
    public float threshold;
    public float prunedSpectralFlux;
    public bool isPeak;
}


/// <summary>
/// Analyzes spectral flux.
/// </summary>
public class SpectralFluxAnalyzer
{
    private readonly int numSamples = 1024;

    // Sensitivity multiplier to scale the average threshold.
    // In this case, if a rectified spectral flux sample is > 1.5 times the average, it is a peak
    private readonly float thresholdMultiplier = 1.5f;

    // Number of samples to average in our window
    private readonly int thresholdWindowSize = 50;

    public List<SpectralFluxInfo> spectralFluxSamples;
    private readonly float[] curSpectrum;
    private readonly float[] prevSpectrum;
    private int indexToProcess;


    /// <summary>
    /// Construct a new spectral flux analyzer.
    /// </summary>
    public SpectralFluxAnalyzer()
    {
        this.spectralFluxSamples = new List<SpectralFluxInfo>();
        // Start processing from middle of first window and increment by 1 from there
        this.indexToProcess = this.thresholdWindowSize / 2;
        this.curSpectrum = new float[this.numSamples];
        this.prevSpectrum = new float[this.numSamples];
    }


    /// <summary>
    /// Sets current spectrum.
    /// </summary>
    /// <param name="spectrum">Current spectrum to set.</param>
    public void SetCurSpectrum(float[] spectrum)
    {
        this.curSpectrum.CopyTo(this.prevSpectrum, 0);
        spectrum.CopyTo(this.curSpectrum, 0);
    }

    /// <summary>
    /// Analyzes the spectrum flux for the given spectrum at the given time.
    /// </summary>
    /// <param name="spectrum">The spectrum.</param>
    /// <param name="time">The time.</param>
    public void AnalyzeSpectrum(float[] spectrum, float time)
    {
        // Set spectrum
        this.SetCurSpectrum(spectrum);
        // Get current spectral flux from spectrum
        SpectralFluxInfo curInfo = new SpectralFluxInfo
        {
            time = time,
            spectralFlux = this.CalculateRectifiedSpectralFlux()
        };
        this.spectralFluxSamples.Add(curInfo);
        // We have enough samples to detect a peak
        if(this.spectralFluxSamples.Count >= this.thresholdWindowSize)
        {
            // Get Flux threshold of time window surrounding index to process
            this.spectralFluxSamples[this.indexToProcess].threshold = this.GetFluxThreshold(this.indexToProcess);
            // Only keep amp amount above threshold to allow peak filtering
            this.spectralFluxSamples[this.indexToProcess].prunedSpectralFlux = this.GetPrunedSpectralFlux(this.indexToProcess);
            // Now that we are processed at n, n-1 has neighbors (n-2, n) to determine peak
            int indexToDetectPeak = this.indexToProcess - 1;
            bool curPeak = this.IsPeak(indexToDetectPeak);
            if(curPeak)
            {
                this.spectralFluxSamples[indexToDetectPeak].isPeak = true;
            }
            this.indexToProcess++;
        }
        else
        {
            Debug.Log(string.Format("Not ready yet.  At spectral flux sample size of {0} growing to {1}", this.spectralFluxSamples.Count, this.thresholdWindowSize));
        }
    }

    /// <summary>
    /// Calculates the rectified spectral flux.
    /// </summary>
    /// <returns>Returns the rectified spectral flux.</returns>
    private float CalculateRectifiedSpectralFlux()
    {
        float sum = 0f;
        // Aggregate positive changes in spectrum data
        for(int i = 0; i < this.numSamples; i++)
        {
            sum += Mathf.Max(0f, this.curSpectrum[i] - this.prevSpectrum[i]);
        }
        return sum;
    }

    /// <summary>
    /// Gets the flux threshold at the given index.
    /// </summary>
    /// <param name="spectralFluxIndex">The index to check for a spectral flux threshold.</param>
    /// <returns>Returns the flux threshold.</returns>
    private float GetFluxThreshold(int spectralFluxIndex)
    {
        // How many samples in the past and future we include in our average
        int windowStartIndex = Mathf.Max(0, spectralFluxIndex - (this.thresholdWindowSize / 2));
        int windowEndIndex = Mathf.Min(this.spectralFluxSamples.Count - 1, spectralFluxIndex + (this.thresholdWindowSize / 2));
        // Add up our spectral flux over the window
        float sum = 0f;
        for(int i = windowStartIndex; i < windowEndIndex; i++)
        {
            sum += this.spectralFluxSamples[i].spectralFlux;
        }
        // Return the average multiplied by our sensitivity multiplier
        float avg = sum / (windowEndIndex - windowStartIndex);
        return avg * this.thresholdMultiplier;
    }

    /// <summary>
    /// Gets the pruned spectral flux.
    /// </summary>
    /// <param name="spectralFluxIndex">The index to prune.</param>
    /// <returns>Returns the pruned spectral flux.</returns>
    private float GetPrunedSpectralFlux(int spectralFluxIndex)
    {
        return Mathf.Max(0f, this.spectralFluxSamples[spectralFluxIndex].spectralFlux - this.spectralFluxSamples[spectralFluxIndex].threshold);
    }

    /// <summary>
    /// Checks if there is a peak at the given index.
    /// </summary>
    /// <param name="spectralFluxIndex">The index to check.</param>
    /// <returns>Returns true if there exists a peak at the index.</returns>
    private bool IsPeak(int spectralFluxIndex)
    {
        if(this.spectralFluxSamples[spectralFluxIndex].prunedSpectralFlux > this.spectralFluxSamples[spectralFluxIndex + 1].prunedSpectralFlux &&
            this.spectralFluxSamples[spectralFluxIndex].prunedSpectralFlux > this.spectralFluxSamples[spectralFluxIndex - 1].prunedSpectralFlux)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
