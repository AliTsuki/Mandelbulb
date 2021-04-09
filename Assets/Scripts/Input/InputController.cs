using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Controls keyboard and mouse input influence over the camera and other functions.
/// </summary>
public class InputController : MonoBehaviour
{
    /// <summary>
    /// The singleton instance of the input controller.
    /// </summary>
    public static InputController Instance;

    /// <summary>
    /// The control input action map.
    /// </summary>
    private InputActions controls;

    [Tooltip("The main camera being moved and rotated by inputs.")]
    public Camera Cam;
    [Tooltip("The movement input from the WASD keys on keyboard.")]
    public Vector3 MoveInput = Vector3.zero;
    [Tooltip("The aim input from mouse movements.")]
    public Vector2 AimInput = Vector2.zero;
    [Tooltip("Should camera movement be at fast speed?")]
    public bool Sprinting = false;

    [Tooltip("Should the power change speed be added to the fractal power each frame?")]
    public bool Paused = true;
    [Range(0f, 1f), Tooltip("The rate at which the fractal power changes over time.")]
    public float PowerChangeSpeed = 0.12f;
    [Range(0.001f, 0.1f), Tooltip("The multiplier applied to the scrollwheel input when altering the power change speed.")]
    public float PowerChangeSensitivity = 0.001f;

    [Range(0.1f, 1f), Tooltip("The default movement speed.")]
    public float DefaultMoveSpeed = 0.2f;
    [Range(1f, 10f), Tooltip("The multiplier to apply to movement speed when sprinting.")]
    public float SprintMultiplier = 5.0f;
    [Tooltip("The current movement speed.")]
    public float Speed = 0f;
    [Range(0.1f, 2f), Tooltip("The multiplier applied to mouse movements on camera aim.")]
    public float MouseSensitivity = 0.8f;
    [Tooltip("Should camera Y axis movements be inverted?")]
    public bool InvertYAxis = true;

    [Tooltip("Should inputs be recorded and applied?")]
    public bool RecordInputs = true;


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
        this.controls = new InputActions();
        this.controls.Main.Movement.performed += this.Movement_performed;
        this.controls.Main.Movement.canceled += this.Movement_canceled;
        this.controls.Main.Aim.performed += this.Aim_performed;
        this.controls.Main.Aim.canceled += this.Aim_canceled;
        this.controls.Main.InvertYAxis.performed += this.InvertYAxis_performed;
        this.controls.Main.Sprint.performed += this.Sprint_performed;
        this.controls.Main.Sprint.canceled += this.Sprint_canceled;
        this.controls.Main.TogglePowerAddition.performed += this.TogglePowerAddition_performed;
        this.controls.Main.ChangePowerAddRate.performed += this.ChangePowerAddRate_performed;
        this.controls.Main.ResetSpeed.performed += this.ResetSpeed_performed;
        this.controls.Main.ResetPower.performed += this.ResetPower_performed;
        this.controls.Main.DecreaseEpsilon.performed += this.DecreaseEpsilon_performed;
        this.controls.Main.IncreaseEpsilon.performed += this.IncreaseEpsilon_performed;
        this.controls.Main.ToggleUI.performed += this.ToggleUI_performed;
        this.controls.Main.Exit.performed += this.Exit_performed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.controls.Enable();
    }

    /// <summary>
    /// Called when the script is disabled.
    /// </summary>
    private void OnDisable()
    {
        this.controls.Disable();
    }

    /// <summary>
    /// FixedUpdate is run a fixed number of times per second.
    /// </summary>
    private void FixedUpdate()
    {
        this.Speed = (this.Sprinting == true) ? this.DefaultMoveSpeed * this.SprintMultiplier : this.DefaultMoveSpeed;
        Vector3 MoveDelta = this.MoveInput * this.Speed * Time.fixedDeltaTime;
        this.Cam.transform.position += (this.Cam.transform.forward * MoveDelta.z) + (this.Cam.transform.right * MoveDelta.x);
        Vector2 AimDelta = this.AimInput * this.MouseSensitivity * Time.fixedDeltaTime;
        if(this.InvertYAxis == true)
        {
            this.Cam.transform.Rotate(AimDelta.y, AimDelta.x, 0f);
        }
        else
        {
            this.Cam.transform.Rotate(-AimDelta.y, AimDelta.x, 0f);
        }
    }

    /// <summary>
    /// Called when the movement input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Movement_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.MoveInput = new Vector3(context.ReadValue<Vector2>().x, 0f, context.ReadValue<Vector2>().y);
        }
    }

    /// <summary>
    /// Called when the movement input is canceled.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Movement_canceled(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.MoveInput = new Vector3(context.ReadValue<Vector2>().x, 0f, context.ReadValue<Vector2>().y);
        }
    }

    /// <summary>
    /// Called when the aim input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Aim_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.AimInput = context.ReadValue<Vector2>();
        }
    }

    /// <summary>
    /// Called when the aim input is canceled.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Aim_canceled(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.AimInput = context.ReadValue<Vector2>();
        }
    }

    /// <summary>
    /// Called when the invert y axis input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void InvertYAxis_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.InvertYAxis = !this.InvertYAxis;
        }
    }

    /// <summary>
    /// Called when the sprint input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Sprint_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.Sprinting = true;
        }
    }

    /// <summary>
    /// Called when the sprint input is canceled.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Sprint_canceled(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.Sprinting = false;
        }
    }

    /// <summary>
    /// Called when the toggle power addition input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void TogglePowerAddition_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.Paused = !this.Paused;
        }
    }

    /// <summary>
    /// Called when the change power add rate input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void ChangePowerAddRate_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.PowerChangeSpeed += context.ReadValue<float>() * this.PowerChangeSensitivity;
            if(this.PowerChangeSpeed > 0f && this.PowerChangeSpeed < 0.12f)
            {
                this.PowerChangeSpeed = 0f;
            }
            else if(this.PowerChangeSpeed < 0f && this.PowerChangeSpeed > -0.12f)
            {
                this.PowerChangeSpeed = 0f;
            }
        }
    }

    /// <summary>
    /// Called when the reset speed input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void ResetSpeed_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.PowerChangeSpeed = 0f;
        }
    }

    /// <summary>
    /// Called when the reset power input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void ResetPower_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            RaymarchController.Instance.FractalPower = 1f;
        }
    }

    /// <summary>
    /// Called when the decrease epsilon input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void DecreaseEpsilon_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            RaymarchController.Instance.ModifyEpsilon(false);
        }
    }

    /// <summary>
    /// Called when the increase epsilon input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void IncreaseEpsilon_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            RaymarchController.Instance.ModifyEpsilon(true);
        }
    }

    /// <summary>
    /// Called when the toggle UI input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void ToggleUI_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            UIController.Instance.ToggleUI();
        }
    }

    /// <summary>
    /// Called when the exit input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void Exit_performed(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    /// <summary>
    /// Called when the debug unhook input is performed.
    /// </summary>
    /// <param name="context">The data passed by the input.</param>
    private void DebugUnhookInput_performed(InputAction.CallbackContext context)
    {
        Cursor.visible = !Cursor.visible;
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        this.RecordInputs = !this.RecordInputs;
        this.MoveInput = Vector3.zero;
        this.AimInput = Vector3.zero;
    }
}
