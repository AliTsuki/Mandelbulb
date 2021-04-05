using System;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


[Serializable, VolumeComponentMenu("Post-processing/Custom/GaussianBlurPostProcess")]
public sealed class GaussianBlurPostProcess : CustomPostProcessVolumeComponent, IPostProcessComponent
{
    [Tooltip("Controls the max number of steps.")]
    public UnityEngine.Rendering.ClampedIntParameter MaxSteps = new ClampedIntParameter(0, 0, 10);

    private Material m_Material;

    public bool IsActive() => this.m_Material != null && this.MaxSteps.value > 0;

    public override CustomPostProcessInjectionPoint injectionPoint => CustomPostProcessInjectionPoint.BeforePostProcess;

    private const string kShaderName = "Hidden/Shader/GaussianBlurPostProcessShader";

    public override void Setup()
    {
        if(Shader.Find(kShaderName) != null)
        {
            this.m_Material = new Material(Shader.Find(kShaderName));
        }
        else
        {
            Debug.LogError($"Unable to find shader '{kShaderName}'. Post Process Volume GaussianBlurPostProcess is unable to load.");
        }
    }

    public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
    {
        if(this.m_Material == null)
        {
            return;
        }
        this.m_Material.SetInt("_MaxSteps", this.MaxSteps.value);
        this.m_Material.SetTexture("_InputTexture", source);
        HDUtils.DrawFullScreen(cmd, this.m_Material, destination);
    }

    public override void Cleanup()
    {
        CoreUtils.Destroy(this.m_Material);
    }
}