using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// The controller that sends data to the raymarch compute shader.
/// </summary>
public class RaymarchController : MonoBehaviour
{
    /// <summary>
    /// The singleton instance of the raymarch controller.
    /// </summary>
    public static RaymarchController Instance;

    [Tooltip("The compute shader for rendering.")]
    public ComputeShader RaymarchShader;
    [Tooltip("The render texture to contain rendered image.")]
    public RenderTexture RenderTex;
    [Tooltip("The main camera used for position/rotation data in rendering image.")]
    public Camera Cam;
    [Tooltip("The main light source used for directional lighting.")]
    public Light MainLight;
    [Tooltip("The raw image UI component to contain the rendered image.")]
    public RawImage Screen;

    [Range(1f, 30f), Tooltip("The fractal power. Higher values result in more self similar looking surface.")]
    public float FractalPowerBaseline = 1f;
    [Tooltip("The current fractal power.")]
    public float FractalPower = 1f;
    [Tooltip("The current amount to add to fractal power this frame.")]
    public float FractalPowerAdd = 1f;
    [Tooltip("Is the audio playing peaking this frame in the spectral flux?")]
    public bool SpectralFluxPeakThisFrame = false;
    [Tooltip("The current spectral flux this frame.")]
    public float SpectralFluxThisFrame = 0f;
    [Range(0f, 1f), Tooltip("The amount to add to fractal power during peaks.")]
    public float FractalPowerPeakAddAmount = 0.25f;
    [Range(0, 1f), Tooltip("The rate to return to baseline after a peak.")]
    public float FractalPowerPeakLerpDownRate = 0.5f;
    [Range(0.0001f, 0.001f), Tooltip("The small number to use as how close to try to get to the surface for each ray. Smaller number results in more surface detail at the expense of more render time.")]
    public float Epsilon = 0.001f;
    [Range(1f, 10f), Tooltip("The maximum distance to send a ray. Surfaces beyond this distance will not be rendered.")]
    public float MaxDistance = 5f;
    [Range(1, 500), Tooltip("The maximum number of steps for the raymarcher to iterate through.")]
    public int MaxSteps = 250;
    [Range(0f, 10f), Tooltip("The distance where fog will start to affect the color of the surface.")]
    public float FogDistance = 3f;
    [Range(0f, 50f), Tooltip("The intensity of the main light source. Higher values lead to higher contrast between light and dark surfaces.")]
    public float LightIntensity = 7f;
    [ColorUsage(false, false), Tooltip("The color of the background at infinite distance behind rendered surface.")]
    public Color BackgroundColor;
    [ColorUsage(false, false), Tooltip("The color of the glow around the edges of the rendered surface.")]
    public Color GlowColor;
    [ColorUsage(false, false), Tooltip("The color of the main light source.")]
    public Color LightColor;
    public enum ColorChannel
    {
        R,
        G,
        B
    }
    public ColorChannel AmbientColorChannel = ColorChannel.R;
    [Range(0f, 1f), Tooltip("The rate of change in the hue of the ambient color over time.")]
    public float AmbientColorRotationAmount = 0.25f;
    [Range(0f, 1f), Tooltip("The maximum saturation of the ambient color.")]
    public float AmbientColorMaxChannelAmount = 0.5f;
    [ColorUsage(false, false), Tooltip("The starting ambient color.")]
    public Color AmbientColor;
    [Tooltip("The gradient for the diffuse color of the surface.")]
    public Texture2D DiffuseColorGradient;
    [ColorUsage(false, false), Tooltip("The color of the specular highlights.")]
    public Color SpecularColor;
    [Range(0.01f, 10f), Tooltip("The shininess of the surface, the lower the value the wider the specular highlights on the surface.")]
    public float Shininess = 10f;
    [Range(0f, 1f), Tooltip("The minimum brightness of the direct shadows. Lower numbers make darker shadows.")]
    public float ShadowMin = 0.1f;
    [Range(0f, 0.002f), Tooltip("The largest minimum distance to use in the ratio for calculating the softness of the shadows.")]
    public float ShadowDistance = 0.002f;
    [Range(1, 250), Tooltip("The max steps to use in calculating the darkness applied from ambient occlusion.")]
    public int AOStepLimit = 100;
    [Range(1, 250), Tooltip("The max steps to use in calculating the amount of glow to add.")]
    public int GlowStepLimit = 100;
    [Range(0.01f, 10f)]
    public float colorDistanceRatio = 3f;

    private bool forward = true;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
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
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    private void Update()
    {
        if(Application.isPlaying == true)
        {
            if(this.forward == true)
            {
                this.FractalPowerBaseline += InputController.Instance.PowerChangeSpeed * Time.deltaTime;
                if(this.SpectralFluxPeakThisFrame == true)
                {
                    this.FractalPowerAdd = this.FractalPowerPeakAddAmount * this.SpectralFluxThisFrame;
                }
                else
                {
                    this.FractalPowerAdd = Mathf.Lerp(this.FractalPowerAdd, -this.FractalPowerPeakAddAmount, this.FractalPowerPeakLerpDownRate);
                }
                this.FractalPower = this.FractalPowerBaseline + this.FractalPowerAdd;
                if(this.FractalPower > 9f)
                {
                    this.forward = false;
                }
            }
            else
            {
                this.FractalPowerBaseline -= InputController.Instance.PowerChangeSpeed * Time.deltaTime;
                if(this.SpectralFluxPeakThisFrame == true)
                {
                    this.FractalPowerAdd = -this.FractalPowerPeakAddAmount * this.SpectralFluxThisFrame;
                }
                else
                {
                    this.FractalPowerAdd = Mathf.Lerp(this.FractalPowerAdd, this.FractalPowerPeakAddAmount, this.FractalPowerPeakLerpDownRate);
                }
                this.FractalPower = this.FractalPowerBaseline - this.FractalPowerAdd;
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
    /// Updates the parameters of the compute shader.
    /// </summary>
    private void SetComputeShaderParameters()
    {
        this.RaymarchShader.SetTexture(0, "destination", this.RenderTex);

        this.RaymarchShader.SetMatrix("cameraToWorld", this.Cam.cameraToWorldMatrix);
        this.RaymarchShader.SetMatrix("cameraInverseProjection", this.Cam.projectionMatrix.inverse);
        this.RaymarchShader.SetVector("viewDirection", this.Cam.transform.forward);
        this.RaymarchShader.SetVector("lightDirection", this.MainLight.transform.forward);

        this.RaymarchShader.SetFloat("power", Mathf.Max(this.FractalPower, 1.01f));
        this.RaymarchShader.SetFloat("epsilon", this.Epsilon);
        this.RaymarchShader.SetFloat("maxDistance", this.MaxDistance);
        this.RaymarchShader.SetInt("maxSteps", this.MaxSteps);

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
        this.RaymarchShader.SetInt("glowStepLimit", this.GlowStepLimit);

        this.RaymarchShader.SetFloat("colorDistanceRatio", this.colorDistanceRatio);
    }

    /// <summary>
    /// Initializes the render texture.
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
            this.Screen.texture = this.RenderTex;
        }
    }

    /// <summary>
    /// Rotates the hue of the ambient color used to light the surface over time. Goes around the color wheel > Red, Purple, Blue, Teal, Green, Yellow, Orange, Red...
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

    /// <summary>
    /// Increase or decrease epsilon.
    /// </summary>
    /// <param name="add">Should epsilon be added to or subtracted from.</param>
    public void ModifyEpsilon(bool add)
    {
        if(add == true)
        {
            this.Epsilon += this.Epsilon * 0.1f;
        }
        else
        {
            this.Epsilon -= this.Epsilon * 0.1f;
        }
    }
}
