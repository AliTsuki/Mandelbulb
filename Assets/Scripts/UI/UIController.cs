using System;

using TMPro;

using UnityEngine;


/// <summary>
/// 
/// </summary>
public class UIController : MonoBehaviour
{
    public TextMeshProUGUI DebugText;


    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        this.DebugText.text = $@"Horizontal Move Input: {InputController.Instance.MoveInput}{Environment.NewLine}Aim Input: {InputController.Instance.AimInput}{Environment.NewLine}Power Change Speed: {InputController.Instance.PowerChangeSpeed}{Environment.NewLine}Power: {RaymarchController.Instance.FractalPower}";
    }
}
