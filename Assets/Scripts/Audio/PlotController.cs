using System.Collections.Generic;

using UnityEngine;


/// <summary>
/// Controls the plotter for displaying spectral flux into a graph.
/// </summary>
public class PlotController : MonoBehaviour
{
    public List<Transform> plotPoints;
    public int displayWindowSize = 300;

    public Transform BasePoint;
    public float DisplayMultiplier;


    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        this.plotPoints = new List<Transform>();
        float localWidth = this.BasePoint.localScale.x;
        // -n/2...0...n/2
        for(int i = 0; i < this.displayWindowSize; i++)
        {
            //Instantiate point
            Transform t = (Instantiate(Resources.Load("Point"), this.transform) as GameObject).transform;
            // Set position
            float pointX = (this.displayWindowSize / 2 * -1 * localWidth) + (i * localWidth);
            t.localPosition = new Vector3(pointX, t.localPosition.y, t.localPosition.z);
            this.plotPoints.Add(t);
        }
    }

    /// <summary>
    /// Updates the current plot.
    /// </summary>
    /// <param name="pointInfo">The point info.</param>
    /// <param name="curIndex">The current index.</param>
    public void UpdatePlot(List<SpectralFluxInfo> pointInfo, int curIndex = -1)
    {
        if(this.plotPoints.Count < this.displayWindowSize - 1)
        {
            return;
        }
        int numPlotted = 0;
        int windowEnd;
        int windowStart;
        if(curIndex > 0)
        {
            windowStart = Mathf.Max(0, curIndex - (this.displayWindowSize / 2));
            windowEnd = Mathf.Min(curIndex + (this.displayWindowSize / 2), pointInfo.Count - 1);
        }
        else
        {
            windowStart = Mathf.Max(0, pointInfo.Count - this.displayWindowSize - 1);
            windowEnd = Mathf.Min(windowStart + this.displayWindowSize, pointInfo.Count);
        }
        for(int i = windowStart; i < windowEnd; i++)
        {
            int plotIndex = numPlotted;
            numPlotted++;
            Transform fluxPoint = this.plotPoints[plotIndex].Find("FluxPoint");
            Transform threshPoint = this.plotPoints[plotIndex].Find("ThreshPoint");
            Transform peakPoint = this.plotPoints[plotIndex].Find("PeakPoint");
            if(pointInfo[i].isPeak)
            {
                this.SetPointHeight(peakPoint, pointInfo[i].spectralFlux);
                this.SetPointHeight(fluxPoint, 0f);
            }
            else
            {
                this.SetPointHeight(fluxPoint, pointInfo[i].spectralFlux);
                this.SetPointHeight(peakPoint, 0f);
            }
            this.SetPointHeight(threshPoint, pointInfo[i].threshold);
        }
    }

    /// <summary>
    /// Sets the point height for the given point.
    /// </summary>
    /// <param name="point">The point to set.</param>
    /// <param name="height">The height to apply to point.</param>
    public void SetPointHeight(Transform point, float height)
    {
        point.localPosition = new Vector3(point.localPosition.x, height * this.DisplayMultiplier, point.localPosition.z);
    }
}