using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 
/// </summary>
public class InputController : MonoBehaviour
{
    public static InputController Instance;

    private InputActions controls;

    public Camera Cam;
    public Vector3 MoveInput = Vector3.zero;
    public bool DecayMoveInput = true;
    public Vector2 AimInput = Vector2.zero;
    public bool Sprinting = false;
    public bool Paused = false;
    public float PowerChangeSpeed = 0.01f;

    public float DefaultMoveSpeed = 0.2f;
    public float SprintMultiplier = 5.0f;
    public float Speed = 0f;
    public float SpeedDecayRate = 0.9f;

    public float MouseSensitivity = 0.8f;

    public float PowerChangeSensitivity = 0.001f;

    public bool RecordInputs = true;


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
        this.controls = new InputActions();
        this.controls.Main.Movement.performed += this.Movement_performed;
        this.controls.Main.Movement.canceled += this.Movement_canceled;
        this.controls.Main.Aim.performed += this.Aim_performed;
        this.controls.Main.Aim.canceled += this.Aim_canceled;
        this.controls.Main.Sprint.performed += this.Sprint_performed;
        this.controls.Main.Sprint.canceled += this.Sprint_canceled;
        this.controls.Main.TogglePower.performed += this.TogglePower_performed;
        this.controls.Main.Acceleration.performed += this.Acceleration_performed;
        this.controls.Main.Exit.performed += this.Exit_performed;
        this.controls.Main.DEBUGUNHOOKINPUT.performed += this.DebugUnhookInput_performed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.controls.Enable();
    }

    private void OnDisable()
    {
        this.controls.Disable();
    }

    private void Update()
    {
        this.Speed = (this.Sprinting == true) ? this.DefaultMoveSpeed * this.SprintMultiplier : this.DefaultMoveSpeed;
        Vector3 MoveDelta = this.MoveInput * this.Speed * Time.deltaTime;
        this.Cam.transform.position += (this.Cam.transform.forward * MoveDelta.z) + (this.Cam.transform.right * MoveDelta.x);
        if(this.DecayMoveInput == true)
        {
            if(this.MoveInput.sqrMagnitude > 0.01f)
            {
                this.MoveInput = Vector3.Lerp(this.MoveInput, Vector3.zero, this.SpeedDecayRate);
            }
        }
        Vector2 AimDelta = this.AimInput * this.MouseSensitivity * Time.deltaTime;
        this.Cam.transform.Rotate(AimDelta.y, AimDelta.x, 0f);
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.DecayMoveInput = false;
            this.MoveInput = new Vector3(context.ReadValue<Vector2>().x, 0f, context.ReadValue<Vector2>().y);
        }
    }

    private void Movement_canceled(InputAction.CallbackContext context)
    {
        this.DecayMoveInput = true;
    }

    private void Aim_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.AimInput = context.ReadValue<Vector2>();
        }
    }

    private void Aim_canceled(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.AimInput = context.ReadValue<Vector2>();
        }
    }

    private void Sprint_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.Sprinting = true;
        }
    }

    private void Sprint_canceled(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.Sprinting = false;
        }
    }

    private void TogglePower_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.Paused = !this.Paused;
        }
    }

    private void Acceleration_performed(InputAction.CallbackContext context)
    {
        if(this.RecordInputs == true)
        {
            this.PowerChangeSpeed += context.ReadValue<float>() * this.PowerChangeSensitivity;
        }
    }

    private void Exit_performed(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void DebugUnhookInput_performed(InputAction.CallbackContext context)
    {
        if(Cursor.visible == false)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }    
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
