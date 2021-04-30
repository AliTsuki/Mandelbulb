using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Controls the UI for the application.
/// </summary>
public class UIController : MonoBehaviour
{
    /// <summary>
    /// The singleton instance of the UI controller.
    /// </summary>
    public static UIController Instance;

    [Tooltip("The text field for displaying info text.")]
    public TextMeshProUGUI InfoText;
    [Tooltip("The text fields that make up the UI.")]
    public List<TextMeshProUGUI> UITextElements;
    [Tooltip("The play icon.")]
    public Image PlayIcon;
    [Tooltip("The pause icon.")]
    public Image PauseIcon;

    [Tooltip("Should the UI be shown?")]
    public bool ShowUI = true;

    private readonly float[] recentFPS = new float[30];
    private int recentFPSCounter = 0;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    private void Update()
    {
        if(this.ShowUI == true)
        {
            float FPS = 1 / Time.deltaTime;
            this.recentFPS[this.recentFPSCounter] = FPS;
            this.recentFPSCounter++;
            if(this.recentFPSCounter >= this.recentFPS.Length)
            {
                this.recentFPSCounter = 0;
            }
            float AvgFPS = 0;
            foreach(float fps in this.recentFPS)
            {
                AvgFPS += fps;
            }
            AvgFPS /= this.recentFPS.Length;
            this.InfoText.text = $@"Average FPS: {AvgFPS:0}  FPS: {FPS:0}{Environment.NewLine}{Environment.NewLine}Invert Y Axis: {InputController.Instance.InvertYAxis}{Environment.NewLine}{Environment.NewLine}Speed: {InputController.Instance.PowerChangeSpeed:0.00}{Environment.NewLine}Power: {RaymarchController.Instance.FractalPowerBaseline:0.00}{Environment.NewLine}{Environment.NewLine}Epsilon: {RaymarchController.Instance.Epsilon:0.#################}";
            this.PlayIcon.gameObject.SetActive(!InputController.Instance.Paused);
            this.PauseIcon.gameObject.SetActive(InputController.Instance.Paused);
        }
    }

    /// <summary>
    /// Toggles the visibility of the UI.
    /// </summary>
    public void ToggleUI()
    {
        Debug.Log($@"ToggleUI -> ShowUI = {this.ShowUI} -> {!this.ShowUI}");
        this.ShowUI = !this.ShowUI;
        foreach(TextMeshProUGUI uiText in this.UITextElements)
        {
            uiText.gameObject.SetActive(this.ShowUI);
        }
        this.PlayIcon.gameObject.SetActive(this.ShowUI);
        this.PauseIcon.gameObject.SetActive(this.ShowUI);
    }
}
