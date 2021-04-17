// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        this.asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""6a42632a-1d57-4bcf-9080-d19af26f66a0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""52b35486-6f76-4910-821c-2488255f1d88"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""59e95f6f-35c5-4c62-b1cf-bbffc488c7a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYAxis"",
                    ""type"": ""Button"",
                    ""id"": ""05639d25-3c17-4af6-9d3b-38476a43e24f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""400925a9-beb5-487d-b80a-66d4fae409dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TogglePowerAddition"",
                    ""type"": ""Button"",
                    ""id"": ""fab8df28-5745-4416-bbf7-fdb0030b35d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangePowerAddRate"",
                    ""type"": ""Value"",
                    ""id"": ""f1709c36-4c46-4a5a-ad3f-0ebdba537a96"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetSpeed"",
                    ""type"": ""Button"",
                    ""id"": ""01203ed0-12d2-4da7-a236-e63436460a7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetPower"",
                    ""type"": ""Button"",
                    ""id"": ""232e74db-7104-44db-9136-6d4ba69e51b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseEpsilon"",
                    ""type"": ""Button"",
                    ""id"": ""99ca71d7-b499-432e-96df-157ccfae7c59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseEpsilon"",
                    ""type"": ""Button"",
                    ""id"": ""51c096ae-a3bc-4282-8a45-122d305278cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleUI"",
                    ""type"": ""Button"",
                    ""id"": ""b0bcab30-0635-4317-a1ff-a94e02011860"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""2426a2f1-7ac8-4878-ae65-d91a536aa87f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DEBUGUNHOOKINPUT"",
                    ""type"": ""Button"",
                    ""id"": ""0315d158-b9b3-48f0-9059-43d5acfcddce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d5c4594b-b052-4e9e-800d-04f30f20e82b"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c729569b-d287-41cc-b9cf-b5193d6bfb5c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bff10925-dd3b-4e11-b493-b03efad081ab"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fd18ee46-759d-4954-85ce-25e7f8843169"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b16058bc-8975-4df9-86ff-7daa38695e4b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""338480b9-59c1-4bcd-a024-74022c0e69d3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76a49997-586f-4a34-9bcf-500cca874b21"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""TogglePowerAddition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""510ab15f-9b1d-41fd-9df5-53289797483d"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ChangePowerAddRate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13746e09-c242-4286-960c-8edb9af7e180"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8046a7d9-adcc-4adf-abf9-9f756ad338a6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f336a04-73a6-4adf-8a87-70a792a4e588"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""DEBUGUNHOOKINPUT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea54552f-1e98-4ab2-aaad-f7e17364cec4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ResetSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c828be2b-606e-4ae0-996c-d70a6c1c98af"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ResetPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72f052f8-bd03-4350-9717-ebfe7cb419c5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""ToggleUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08b93bf4-7b99-4742-aa82-17b563a2c655"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""IncreaseEpsilon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""862c23ab-fd56-481d-9d54-58825e1e543f"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""DecreaseEpsilon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d74e9aac-6383-446a-b068-dc555471e1d3"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""InvertYAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Main
        this.m_Main = this.asset.FindActionMap("Main", throwIfNotFound: true);
        this.m_Main_Movement = this.m_Main.FindAction("Movement", throwIfNotFound: true);
        this.m_Main_Aim = this.m_Main.FindAction("Aim", throwIfNotFound: true);
        this.m_Main_InvertYAxis = this.m_Main.FindAction("InvertYAxis", throwIfNotFound: true);
        this.m_Main_Sprint = this.m_Main.FindAction("Sprint", throwIfNotFound: true);
        this.m_Main_TogglePowerAddition = this.m_Main.FindAction("TogglePowerAddition", throwIfNotFound: true);
        this.m_Main_ChangePowerAddRate = this.m_Main.FindAction("ChangePowerAddRate", throwIfNotFound: true);
        this.m_Main_ResetSpeed = this.m_Main.FindAction("ResetSpeed", throwIfNotFound: true);
        this.m_Main_ResetPower = this.m_Main.FindAction("ResetPower", throwIfNotFound: true);
        this.m_Main_DecreaseEpsilon = this.m_Main.FindAction("DecreaseEpsilon", throwIfNotFound: true);
        this.m_Main_IncreaseEpsilon = this.m_Main.FindAction("IncreaseEpsilon", throwIfNotFound: true);
        this.m_Main_ToggleUI = this.m_Main.FindAction("ToggleUI", throwIfNotFound: true);
        this.m_Main_Exit = this.m_Main.FindAction("Exit", throwIfNotFound: true);
        this.m_Main_DEBUGUNHOOKINPUT = this.m_Main.FindAction("DEBUGUNHOOKINPUT", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(this.asset);
    }

    public InputBinding? bindingMask
    {
        get => this.asset.bindingMask;
        set => this.asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => this.asset.devices;
        set => this.asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => this.asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return this.asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return this.asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Enable()
    {
        this.asset.Enable();
    }

    public void Disable()
    {
        this.asset.Disable();
    }

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Movement;
    private readonly InputAction m_Main_Aim;
    private readonly InputAction m_Main_InvertYAxis;
    private readonly InputAction m_Main_Sprint;
    private readonly InputAction m_Main_TogglePowerAddition;
    private readonly InputAction m_Main_ChangePowerAddRate;
    private readonly InputAction m_Main_ResetSpeed;
    private readonly InputAction m_Main_ResetPower;
    private readonly InputAction m_Main_DecreaseEpsilon;
    private readonly InputAction m_Main_IncreaseEpsilon;
    private readonly InputAction m_Main_ToggleUI;
    private readonly InputAction m_Main_Exit;
    private readonly InputAction m_Main_DEBUGUNHOOKINPUT;
    public struct MainActions
    {
        private @InputActions m_Wrapper;
        public MainActions(@InputActions wrapper) { this.m_Wrapper = wrapper; }
        public InputAction @Movement => this.m_Wrapper.m_Main_Movement;
        public InputAction @Aim => this.m_Wrapper.m_Main_Aim;
        public InputAction @InvertYAxis => this.m_Wrapper.m_Main_InvertYAxis;
        public InputAction @Sprint => this.m_Wrapper.m_Main_Sprint;
        public InputAction @TogglePowerAddition => this.m_Wrapper.m_Main_TogglePowerAddition;
        public InputAction @ChangePowerAddRate => this.m_Wrapper.m_Main_ChangePowerAddRate;
        public InputAction @ResetSpeed => this.m_Wrapper.m_Main_ResetSpeed;
        public InputAction @ResetPower => this.m_Wrapper.m_Main_ResetPower;
        public InputAction @DecreaseEpsilon => this.m_Wrapper.m_Main_DecreaseEpsilon;
        public InputAction @IncreaseEpsilon => this.m_Wrapper.m_Main_IncreaseEpsilon;
        public InputAction @ToggleUI => this.m_Wrapper.m_Main_ToggleUI;
        public InputAction @Exit => this.m_Wrapper.m_Main_Exit;
        public InputAction @DEBUGUNHOOKINPUT => this.m_Wrapper.m_Main_DEBUGUNHOOKINPUT;
        public InputActionMap Get() { return this.m_Wrapper.m_Main; }
        public void Enable() { this.Get().Enable(); }
        public void Disable() { this.Get().Disable(); }
        public bool enabled => this.Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (this.m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                this.@Movement.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                this.@Movement.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                this.@Movement.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                this.@Aim.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                this.@Aim.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                this.@Aim.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                this.@InvertYAxis.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnInvertYAxis;
                this.@InvertYAxis.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnInvertYAxis;
                this.@InvertYAxis.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnInvertYAxis;
                this.@Sprint.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnSprint;
                this.@Sprint.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnSprint;
                this.@Sprint.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnSprint;
                this.@TogglePowerAddition.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnTogglePowerAddition;
                this.@TogglePowerAddition.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnTogglePowerAddition;
                this.@TogglePowerAddition.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnTogglePowerAddition;
                this.@ChangePowerAddRate.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnChangePowerAddRate;
                this.@ChangePowerAddRate.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnChangePowerAddRate;
                this.@ChangePowerAddRate.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnChangePowerAddRate;
                this.@ResetSpeed.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnResetSpeed;
                this.@ResetSpeed.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnResetSpeed;
                this.@ResetSpeed.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnResetSpeed;
                this.@ResetPower.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnResetPower;
                this.@ResetPower.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnResetPower;
                this.@ResetPower.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnResetPower;
                this.@DecreaseEpsilon.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnDecreaseEpsilon;
                this.@DecreaseEpsilon.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnDecreaseEpsilon;
                this.@DecreaseEpsilon.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnDecreaseEpsilon;
                this.@IncreaseEpsilon.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnIncreaseEpsilon;
                this.@IncreaseEpsilon.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnIncreaseEpsilon;
                this.@IncreaseEpsilon.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnIncreaseEpsilon;
                this.@ToggleUI.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnToggleUI;
                this.@ToggleUI.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnToggleUI;
                this.@ToggleUI.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnToggleUI;
                this.@Exit.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                this.@Exit.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                this.@Exit.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                this.@DEBUGUNHOOKINPUT.started -= this.m_Wrapper.m_MainActionsCallbackInterface.OnDEBUGUNHOOKINPUT;
                this.@DEBUGUNHOOKINPUT.performed -= this.m_Wrapper.m_MainActionsCallbackInterface.OnDEBUGUNHOOKINPUT;
                this.@DEBUGUNHOOKINPUT.canceled -= this.m_Wrapper.m_MainActionsCallbackInterface.OnDEBUGUNHOOKINPUT;
            }
            this.m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                this.@Movement.started += instance.OnMovement;
                this.@Movement.performed += instance.OnMovement;
                this.@Movement.canceled += instance.OnMovement;
                this.@Aim.started += instance.OnAim;
                this.@Aim.performed += instance.OnAim;
                this.@Aim.canceled += instance.OnAim;
                this.@InvertYAxis.started += instance.OnInvertYAxis;
                this.@InvertYAxis.performed += instance.OnInvertYAxis;
                this.@InvertYAxis.canceled += instance.OnInvertYAxis;
                this.@Sprint.started += instance.OnSprint;
                this.@Sprint.performed += instance.OnSprint;
                this.@Sprint.canceled += instance.OnSprint;
                this.@TogglePowerAddition.started += instance.OnTogglePowerAddition;
                this.@TogglePowerAddition.performed += instance.OnTogglePowerAddition;
                this.@TogglePowerAddition.canceled += instance.OnTogglePowerAddition;
                this.@ChangePowerAddRate.started += instance.OnChangePowerAddRate;
                this.@ChangePowerAddRate.performed += instance.OnChangePowerAddRate;
                this.@ChangePowerAddRate.canceled += instance.OnChangePowerAddRate;
                this.@ResetSpeed.started += instance.OnResetSpeed;
                this.@ResetSpeed.performed += instance.OnResetSpeed;
                this.@ResetSpeed.canceled += instance.OnResetSpeed;
                this.@ResetPower.started += instance.OnResetPower;
                this.@ResetPower.performed += instance.OnResetPower;
                this.@ResetPower.canceled += instance.OnResetPower;
                this.@DecreaseEpsilon.started += instance.OnDecreaseEpsilon;
                this.@DecreaseEpsilon.performed += instance.OnDecreaseEpsilon;
                this.@DecreaseEpsilon.canceled += instance.OnDecreaseEpsilon;
                this.@IncreaseEpsilon.started += instance.OnIncreaseEpsilon;
                this.@IncreaseEpsilon.performed += instance.OnIncreaseEpsilon;
                this.@IncreaseEpsilon.canceled += instance.OnIncreaseEpsilon;
                this.@ToggleUI.started += instance.OnToggleUI;
                this.@ToggleUI.performed += instance.OnToggleUI;
                this.@ToggleUI.canceled += instance.OnToggleUI;
                this.@Exit.started += instance.OnExit;
                this.@Exit.performed += instance.OnExit;
                this.@Exit.canceled += instance.OnExit;
                this.@DEBUGUNHOOKINPUT.started += instance.OnDEBUGUNHOOKINPUT;
                this.@DEBUGUNHOOKINPUT.performed += instance.OnDEBUGUNHOOKINPUT;
                this.@DEBUGUNHOOKINPUT.canceled += instance.OnDEBUGUNHOOKINPUT;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (this.m_KeyboardMouseSchemeIndex == -1)
            {
                this.m_KeyboardMouseSchemeIndex = this.asset.FindControlSchemeIndex("KeyboardMouse");
            }

            return this.asset.controlSchemes[this.m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnInvertYAxis(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnTogglePowerAddition(InputAction.CallbackContext context);
        void OnChangePowerAddRate(InputAction.CallbackContext context);
        void OnResetSpeed(InputAction.CallbackContext context);
        void OnResetPower(InputAction.CallbackContext context);
        void OnDecreaseEpsilon(InputAction.CallbackContext context);
        void OnIncreaseEpsilon(InputAction.CallbackContext context);
        void OnToggleUI(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnDEBUGUNHOOKINPUT(InputAction.CallbackContext context);
    }
}
