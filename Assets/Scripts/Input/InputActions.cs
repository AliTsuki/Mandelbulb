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
        asset = InputActionAsset.FromJson(@"{
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
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Movement = m_Main.FindAction("Movement", throwIfNotFound: true);
        m_Main_Aim = m_Main.FindAction("Aim", throwIfNotFound: true);
        m_Main_Sprint = m_Main.FindAction("Sprint", throwIfNotFound: true);
        m_Main_TogglePowerAddition = m_Main.FindAction("TogglePowerAddition", throwIfNotFound: true);
        m_Main_ChangePowerAddRate = m_Main.FindAction("ChangePowerAddRate", throwIfNotFound: true);
        m_Main_ResetSpeed = m_Main.FindAction("ResetSpeed", throwIfNotFound: true);
        m_Main_ResetPower = m_Main.FindAction("ResetPower", throwIfNotFound: true);
        m_Main_ToggleUI = m_Main.FindAction("ToggleUI", throwIfNotFound: true);
        m_Main_Exit = m_Main.FindAction("Exit", throwIfNotFound: true);
        m_Main_DEBUGUNHOOKINPUT = m_Main.FindAction("DEBUGUNHOOKINPUT", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Movement;
    private readonly InputAction m_Main_Aim;
    private readonly InputAction m_Main_Sprint;
    private readonly InputAction m_Main_TogglePowerAddition;
    private readonly InputAction m_Main_ChangePowerAddRate;
    private readonly InputAction m_Main_ResetSpeed;
    private readonly InputAction m_Main_ResetPower;
    private readonly InputAction m_Main_ToggleUI;
    private readonly InputAction m_Main_Exit;
    private readonly InputAction m_Main_DEBUGUNHOOKINPUT;
    public struct MainActions
    {
        private @InputActions m_Wrapper;
        public MainActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Main_Movement;
        public InputAction @Aim => m_Wrapper.m_Main_Aim;
        public InputAction @Sprint => m_Wrapper.m_Main_Sprint;
        public InputAction @TogglePowerAddition => m_Wrapper.m_Main_TogglePowerAddition;
        public InputAction @ChangePowerAddRate => m_Wrapper.m_Main_ChangePowerAddRate;
        public InputAction @ResetSpeed => m_Wrapper.m_Main_ResetSpeed;
        public InputAction @ResetPower => m_Wrapper.m_Main_ResetPower;
        public InputAction @ToggleUI => m_Wrapper.m_Main_ToggleUI;
        public InputAction @Exit => m_Wrapper.m_Main_Exit;
        public InputAction @DEBUGUNHOOKINPUT => m_Wrapper.m_Main_DEBUGUNHOOKINPUT;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Aim.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                @Sprint.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSprint;
                @TogglePowerAddition.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTogglePowerAddition;
                @TogglePowerAddition.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTogglePowerAddition;
                @TogglePowerAddition.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTogglePowerAddition;
                @ChangePowerAddRate.started -= m_Wrapper.m_MainActionsCallbackInterface.OnChangePowerAddRate;
                @ChangePowerAddRate.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnChangePowerAddRate;
                @ChangePowerAddRate.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnChangePowerAddRate;
                @ResetSpeed.started -= m_Wrapper.m_MainActionsCallbackInterface.OnResetSpeed;
                @ResetSpeed.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnResetSpeed;
                @ResetSpeed.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnResetSpeed;
                @ResetPower.started -= m_Wrapper.m_MainActionsCallbackInterface.OnResetPower;
                @ResetPower.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnResetPower;
                @ResetPower.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnResetPower;
                @ToggleUI.started -= m_Wrapper.m_MainActionsCallbackInterface.OnToggleUI;
                @ToggleUI.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnToggleUI;
                @ToggleUI.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnToggleUI;
                @Exit.started -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @DEBUGUNHOOKINPUT.started -= m_Wrapper.m_MainActionsCallbackInterface.OnDEBUGUNHOOKINPUT;
                @DEBUGUNHOOKINPUT.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnDEBUGUNHOOKINPUT;
                @DEBUGUNHOOKINPUT.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnDEBUGUNHOOKINPUT;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @TogglePowerAddition.started += instance.OnTogglePowerAddition;
                @TogglePowerAddition.performed += instance.OnTogglePowerAddition;
                @TogglePowerAddition.canceled += instance.OnTogglePowerAddition;
                @ChangePowerAddRate.started += instance.OnChangePowerAddRate;
                @ChangePowerAddRate.performed += instance.OnChangePowerAddRate;
                @ChangePowerAddRate.canceled += instance.OnChangePowerAddRate;
                @ResetSpeed.started += instance.OnResetSpeed;
                @ResetSpeed.performed += instance.OnResetSpeed;
                @ResetSpeed.canceled += instance.OnResetSpeed;
                @ResetPower.started += instance.OnResetPower;
                @ResetPower.performed += instance.OnResetPower;
                @ResetPower.canceled += instance.OnResetPower;
                @ToggleUI.started += instance.OnToggleUI;
                @ToggleUI.performed += instance.OnToggleUI;
                @ToggleUI.canceled += instance.OnToggleUI;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @DEBUGUNHOOKINPUT.started += instance.OnDEBUGUNHOOKINPUT;
                @DEBUGUNHOOKINPUT.performed += instance.OnDEBUGUNHOOKINPUT;
                @DEBUGUNHOOKINPUT.canceled += instance.OnDEBUGUNHOOKINPUT;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnTogglePowerAddition(InputAction.CallbackContext context);
        void OnChangePowerAddRate(InputAction.CallbackContext context);
        void OnResetSpeed(InputAction.CallbackContext context);
        void OnResetPower(InputAction.CallbackContext context);
        void OnToggleUI(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnDEBUGUNHOOKINPUT(InputAction.CallbackContext context);
    }
}
