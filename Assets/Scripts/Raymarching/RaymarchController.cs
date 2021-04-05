using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 
/// </summary>
public class RaymarchController : MonoBehaviour
{
    public static RaymarchController Instance;

    public ComputeShader RaymarchShader;
    public RenderTexture RenderTex;
    public Camera Cam;
    public Light MainLight;
    public RawImage Screen;

    [Range(1f, 30f)]
    public float FractalPower = 1f;
    [Range(0f, 10f)]
    public float FogDistance = 3f;
    [Range(0f, 50f)]
    public float LightIntensity = 2f;
    [ColorUsage(false, false)]
    public Color BackgroundColor;
    [ColorUsage(false, false)]
    public Color GlowColor;
    [ColorUsage(false, false)]
    public Color LightColor;
    public enum ColorChannel
    {
        R,
        G,
        B
    }
    public ColorChannel AmbientColorChannel = ColorChannel.R;
    [Range(0f, 1f)]
    public float AmbientColorRotationAmount = 0.1f;
    [Range(0f, 1f)]
    public float AmbientColorMaxChannelAmount = 0.15f;
    [ColorUsage(false, false)]
    public Color AmbientColor;
    public Texture2D DiffuseColorGradient;
    [ColorUsage(false, false)]
    public Color SpecularColor;
    [Range(0.01f, 10f)]
    public float Shininess = 10f;
    [Range(0f, 1f)]
    public float ShadowMin = 0.05f;
    [Range(0f, 0.002f)]
    public float ShadowDistance = 0.001f;
    [Range(1, 250)]
    public int AOStepLimit = 150;


    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        Instance = this;
        if(this.Cam == null)
        {
            this.Cam = Camera.main;
        }
        if(this.MainLight == null)
        {
            this.MainLight = GameObject.Find("Directional Light").GetComponent<Light>();
        }
        if(this.Screen == null)
        {
            this.Screen = GameObject.Find("Screen").GetComponent<RawImage>();
        }
        this.InitializeRenderTexture();
        this.Screen.texture = this.RenderTex;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if(Application.isPlaying)
        {
            if(InputController.Instance.Paused == false)
            {
                this.FractalPower += InputController.Instance.PowerChangeSpeed * Time.deltaTime;
            }
            if(this.FractalPower < 1f)
            {
                this.FractalPower = 1f;
            }
            else if(this.FractalPower > 40f)
            {
                this.FractalPower = 40f;
            }
            this.InitializeRenderTexture();
            this.SetComputeShaderParameters();
            int threadGroupsX = Mathf.CeilToInt(this.Cam.pixelWidth / 8.0f);
            int threadGroupsY = Mathf.CeilToInt(this.Cam.pixelHeight / 8.0f);
            this.RaymarchShader.Dispatch(0, threadGroupsX, threadGroupsY, 1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetComputeShaderParameters()
    {
        this.RaymarchShader.SetTexture(0, "destination", this.RenderTex);
        this.RaymarchShader.SetMatrix("cameraToWorld", this.Cam.cameraToWorldMatrix);
        this.RaymarchShader.SetMatrix("cameraInverseProjection", this.Cam.projectionMatrix.inverse);
        this.RaymarchShader.SetVector("viewDirection", this.Cam.transform.forward);
        this.RaymarchShader.SetVector("lightDirection", this.MainLight.transform.forward);
        this.RaymarchShader.SetFloat("power", Mathf.Max(this.FractalPower, 1.01f));
        this.RaymarchShader.SetFloat("fogDistance", this.FogDistance);
        this.RaymarchShader.SetFloat("lightIntensity", this.LightIntensity);
        this.RaymarchShader.SetVector("backgroundColor", this.BackgroundColor);
        this.RaymarchShader.SetVector("glowColor", this.GlowColor);
        this.RaymarchShader.SetVector("lightColor", this.LightColor);
        this.RotateAmbientColor();
        this.RaymarchShader.SetVector("ambientColor", this.AmbientColor);
        this.RaymarchShader.SetTexture(0, "diffuseColorGradient", this.DiffuseColorGradient);
        this.RaymarchShader.SetVector("specularColor", this.SpecularColor);
        this.RaymarchShader.SetFloat("shininess", this.Shininess);
        this.RaymarchShader.SetFloat("shadowMin", this.ShadowMin);
        this.RaymarchShader.SetFloat("shadowDistance", this.ShadowDistance);
        this.RaymarchShader.SetInt("aoStepLimit", this.AOStepLimit);
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitializeRenderTexture()
    {
        if(this.RenderTex == null || this.RenderTex.width != this.Cam.pixelWidth || this.RenderTex.height != this.Cam.pixelHeight)
        {
            if(this.RenderTex != null)
            {
                this.RenderTex.Release();
            }
            this.RenderTex = new RenderTexture(this.Cam.pixelWidth, this.Cam.pixelHeight, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear)
            {
                enableRandomWrite = true
            };
            this.RenderTex.Create();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void RotateAmbientColor()
    {
        switch(this.AmbientColorChannel)
        {
            case ColorChannel.R:
            {
                if(this.AmbientColor.r < this.AmbientColorMaxChannelAmount)
                {
                    this.AmbientColor = new Color(this.AmbientColor.r + (this.AmbientColorRotationAmount * Time.deltaTime), this.AmbientColor.g, this.AmbientColor.b);
                }
                else
                {
                    this.AmbientColor = new Color(this.AmbientColor.r, this.AmbientColor.g - (this.AmbientColorRotationAmount * Time.deltaTime), this.AmbientColor.b);
                }
                if(this.AmbientColor.r >= this.AmbientColorMaxChannelAmount && this.AmbientColor.g <= 0.0f)
                {
                    this.AmbientColorChannel = ColorChannel.B;
                }
                break;
            }
            case ColorChannel.G:
            {
                if(this.AmbientColor.g < this.AmbientColorMaxChannelAmount)
                {
                    this.AmbientColor = new Color(this.AmbientColor.r, this.AmbientColor.g + (this.AmbientColorRotationAmount * Time.deltaTime), this.AmbientColor.b);
                }
                else
                {
                    this.AmbientColor = new Color(this.AmbientColor.r, this.AmbientColor.g, this.AmbientColor.b - (this.AmbientColorRotationAmount * Time.deltaTime));
                }
                if(this.AmbientColor.g >= this.AmbientColorMaxChannelAmount && this.AmbientColor.b <= 0.0f)
                {
                    this.AmbientColorChannel = ColorChannel.R;
                }
                break;
            }
            case ColorChannel.B:
            {
                if(this.AmbientColor.b < this.AmbientColorMaxChannelAmount)
                {
                    this.AmbientColor = new Color(this.AmbientColor.r, this.AmbientColor.g, this.AmbientColor.b + (this.AmbientColorRotationAmount * Time.deltaTime));
                }
                else
                {
                    this.AmbientColor = new Color(this.AmbientColor.r - (this.AmbientColorRotationAmount * Time.deltaTime), this.AmbientColor.g, this.AmbientColor.b);
                }
                if(this.AmbientColor.b >= this.AmbientColorMaxChannelAmount && this.AmbientColor.r <= 0.0f)
                {
                    this.AmbientColorChannel = ColorChannel.G;
                }
                break;
            }
        }
    }
}
