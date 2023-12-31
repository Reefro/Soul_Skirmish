//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Rachel/Inputs/ControlMaster.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControlMaster : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlMaster"",
    ""maps"": [
        {
            ""name"": ""BaseControls"",
            ""id"": ""3ec51b1d-dced-4263-a115-7070358c8732"",
            ""actions"": [
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""7b2554a7-d5c8-4f12-8051-919dfa096f10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""59cc969e-f809-4b69-ba99-f0ca32e383dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""2397cd48-2a95-4a1e-bd3b-dbf0a42d79c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""d9bfe2c2-682d-41ba-9bdf-bf1c13c4f88a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""2e62f439-41c1-4b07-992b-fa6220f1d207"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""01d2c915-3b21-4fd9-a5df-5a8d2b32d948"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""de9c0851-32a1-48fb-92f2-45bc81904077"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Light_Attack"",
                    ""type"": ""Button"",
                    ""id"": ""8b2a9317-d849-433d-a063-1c03ed61f824"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heavy_Attack"",
                    ""type"": ""Button"",
                    ""id"": ""01e42530-a3bc-4a2e-b051-fea2587cd825"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aba2bcb2-1ed2-421f-be0b-1287421a2d8f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8695d8ff-6284-4717-9a86-f4dd473a79e4"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d04c7909-5db1-4098-9b0c-f65c771f23ab"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69144fcc-ab79-40f8-9372-1537dcd4b067"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0580b536-4f50-4da0-8f36-469f47070380"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5acf44dd-ed3a-417c-ac1a-b77bc844e412"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8c40337-0303-480d-9e30-93a6f5781587"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9188176-8fc7-419d-aa89-ed859077e41e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3a52a64-361d-494f-b9a3-a5e006b1fa1e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BaseControls
        m_BaseControls = asset.FindActionMap("BaseControls", throwIfNotFound: true);
        m_BaseControls_Join = m_BaseControls.FindAction("Join", throwIfNotFound: true);
        m_BaseControls_North = m_BaseControls.FindAction("North", throwIfNotFound: true);
        m_BaseControls_East = m_BaseControls.FindAction("East", throwIfNotFound: true);
        m_BaseControls_South = m_BaseControls.FindAction("South", throwIfNotFound: true);
        m_BaseControls_West = m_BaseControls.FindAction("West", throwIfNotFound: true);
        m_BaseControls_Horizontal = m_BaseControls.FindAction("Horizontal", throwIfNotFound: true);
        m_BaseControls_Jump = m_BaseControls.FindAction("Jump", throwIfNotFound: true);
        m_BaseControls_Light_Attack = m_BaseControls.FindAction("Light_Attack", throwIfNotFound: true);
        m_BaseControls_Heavy_Attack = m_BaseControls.FindAction("Heavy_Attack", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // BaseControls
    private readonly InputActionMap m_BaseControls;
    private IBaseControlsActions m_BaseControlsActionsCallbackInterface;
    private readonly InputAction m_BaseControls_Join;
    private readonly InputAction m_BaseControls_North;
    private readonly InputAction m_BaseControls_East;
    private readonly InputAction m_BaseControls_South;
    private readonly InputAction m_BaseControls_West;
    private readonly InputAction m_BaseControls_Horizontal;
    private readonly InputAction m_BaseControls_Jump;
    private readonly InputAction m_BaseControls_Light_Attack;
    private readonly InputAction m_BaseControls_Heavy_Attack;
    public struct BaseControlsActions
    {
        private @ControlMaster m_Wrapper;
        public BaseControlsActions(@ControlMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Join => m_Wrapper.m_BaseControls_Join;
        public InputAction @North => m_Wrapper.m_BaseControls_North;
        public InputAction @East => m_Wrapper.m_BaseControls_East;
        public InputAction @South => m_Wrapper.m_BaseControls_South;
        public InputAction @West => m_Wrapper.m_BaseControls_West;
        public InputAction @Horizontal => m_Wrapper.m_BaseControls_Horizontal;
        public InputAction @Jump => m_Wrapper.m_BaseControls_Jump;
        public InputAction @Light_Attack => m_Wrapper.m_BaseControls_Light_Attack;
        public InputAction @Heavy_Attack => m_Wrapper.m_BaseControls_Heavy_Attack;
        public InputActionMap Get() { return m_Wrapper.m_BaseControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseControlsActions set) { return set.Get(); }
        public void SetCallbacks(IBaseControlsActions instance)
        {
            if (m_Wrapper.m_BaseControlsActionsCallbackInterface != null)
            {
                @Join.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnJoin;
                @Join.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnJoin;
                @Join.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnJoin;
                @North.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnNorth;
                @East.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnEast;
                @East.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnEast;
                @East.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnEast;
                @South.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnSouth;
                @South.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnSouth;
                @South.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnSouth;
                @West.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnWest;
                @Horizontal.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnJump;
                @Light_Attack.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnLight_Attack;
                @Light_Attack.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnLight_Attack;
                @Light_Attack.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnLight_Attack;
                @Heavy_Attack.started -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnHeavy_Attack;
                @Heavy_Attack.performed -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnHeavy_Attack;
                @Heavy_Attack.canceled -= m_Wrapper.m_BaseControlsActionsCallbackInterface.OnHeavy_Attack;
            }
            m_Wrapper.m_BaseControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Join.started += instance.OnJoin;
                @Join.performed += instance.OnJoin;
                @Join.canceled += instance.OnJoin;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Light_Attack.started += instance.OnLight_Attack;
                @Light_Attack.performed += instance.OnLight_Attack;
                @Light_Attack.canceled += instance.OnLight_Attack;
                @Heavy_Attack.started += instance.OnHeavy_Attack;
                @Heavy_Attack.performed += instance.OnHeavy_Attack;
                @Heavy_Attack.canceled += instance.OnHeavy_Attack;
            }
        }
    }
    public BaseControlsActions @BaseControls => new BaseControlsActions(this);
    public interface IBaseControlsActions
    {
        void OnJoin(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnEast(InputAction.CallbackContext context);
        void OnSouth(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLight_Attack(InputAction.CallbackContext context);
        void OnHeavy_Attack(InputAction.CallbackContext context);
    }
}
