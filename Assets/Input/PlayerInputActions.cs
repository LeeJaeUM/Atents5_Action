//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bf4c78a4-de4e-4e89-9202-0650c648fad2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""bd1f373c-be80-4c92-bb06-681eb7be195c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveModeChange"",
                    ""type"": ""Button"",
                    ""id"": ""18a3e5a0-ade4-4333-8377-76fe93565c64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7fb3c5ea-4b17-45b7-9034-0a357b4c5110"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7315ec1a-1439-4d05-b220-d6787d69747f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""km"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c578b0c4-8123-4113-b5d7-00adb03458c8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""km"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ea9f48ad-3bcd-4f03-ab07-328a2ad87c4c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""km"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8195664e-c607-4a34-9ec8-297fb9516832"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""km"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1644ddca-fbb7-4470-973f-4cc6706f8a11"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveModeChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Effect"",
            ""id"": ""aa138053-0d3f-4ee4-9d72-7fc5506c817d"",
            ""actions"": [
                {
                    ""name"": ""PointerMove"",
                    ""type"": ""Value"",
                    ""id"": ""2d60a0e9-7aa4-49e4-8e6a-706cf7ed09ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""57b01463-ea54-4ee4-b0b9-7711164c2e17"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""km"",
            ""bindingGroup"": ""km"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_MoveModeChange = m_Player.FindAction("MoveModeChange", throwIfNotFound: true);
        // Effect
        m_Effect = asset.FindActionMap("Effect", throwIfNotFound: true);
        m_Effect_PointerMove = m_Effect.FindAction("PointerMove", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_MoveModeChange;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @MoveModeChange => m_Wrapper.m_Player_MoveModeChange;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @MoveModeChange.started += instance.OnMoveModeChange;
            @MoveModeChange.performed += instance.OnMoveModeChange;
            @MoveModeChange.canceled += instance.OnMoveModeChange;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @MoveModeChange.started -= instance.OnMoveModeChange;
            @MoveModeChange.performed -= instance.OnMoveModeChange;
            @MoveModeChange.canceled -= instance.OnMoveModeChange;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Effect
    private readonly InputActionMap m_Effect;
    private List<IEffectActions> m_EffectActionsCallbackInterfaces = new List<IEffectActions>();
    private readonly InputAction m_Effect_PointerMove;
    public struct EffectActions
    {
        private @PlayerInputActions m_Wrapper;
        public EffectActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PointerMove => m_Wrapper.m_Effect_PointerMove;
        public InputActionMap Get() { return m_Wrapper.m_Effect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EffectActions set) { return set.Get(); }
        public void AddCallbacks(IEffectActions instance)
        {
            if (instance == null || m_Wrapper.m_EffectActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_EffectActionsCallbackInterfaces.Add(instance);
            @PointerMove.started += instance.OnPointerMove;
            @PointerMove.performed += instance.OnPointerMove;
            @PointerMove.canceled += instance.OnPointerMove;
        }

        private void UnregisterCallbacks(IEffectActions instance)
        {
            @PointerMove.started -= instance.OnPointerMove;
            @PointerMove.performed -= instance.OnPointerMove;
            @PointerMove.canceled -= instance.OnPointerMove;
        }

        public void RemoveCallbacks(IEffectActions instance)
        {
            if (m_Wrapper.m_EffectActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IEffectActions instance)
        {
            foreach (var item in m_Wrapper.m_EffectActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_EffectActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public EffectActions @Effect => new EffectActions(this);
    private int m_kmSchemeIndex = -1;
    public InputControlScheme kmScheme
    {
        get
        {
            if (m_kmSchemeIndex == -1) m_kmSchemeIndex = asset.FindControlSchemeIndex("km");
            return asset.controlSchemes[m_kmSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveModeChange(InputAction.CallbackContext context);
    }
    public interface IEffectActions
    {
        void OnPointerMove(InputAction.CallbackContext context);
    }
}
