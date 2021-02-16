// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""terrain"",
            ""id"": ""4322c2de-0908-48b3-96b1-95b988861fbd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""cf78c44f-da2f-47d6-9d0d-fb3334f304c2"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""359a19d9-f52d-45b1-88a3-25d5bb570c1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""bb71f9b5-9e9e-4f96-8c74-48ec25ca21d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b1a372ea-9383-4fd1-be0d-cc2d0b5ec45d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""abedd4dc-3cc4-4d23-8b42-38c35cc9f6cb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""81a3fc4a-69ff-402c-9523-b6a2ff82efe1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""20f0c333-9d4b-41e1-81d9-7f0a23abdf4d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca98173c-76f4-4868-aea9-d6e52b1d96ed"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7215574-20c4-4d39-a395-9810365be40e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // terrain
        m_terrain = asset.FindActionMap("terrain", throwIfNotFound: true);
        m_terrain_Movement = m_terrain.FindAction("Movement", throwIfNotFound: true);
        m_terrain_jump = m_terrain.FindAction("jump", throwIfNotFound: true);
        m_terrain_Down = m_terrain.FindAction("Down", throwIfNotFound: true);
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

    // terrain
    private readonly InputActionMap m_terrain;
    private ITerrainActions m_TerrainActionsCallbackInterface;
    private readonly InputAction m_terrain_Movement;
    private readonly InputAction m_terrain_jump;
    private readonly InputAction m_terrain_Down;
    public struct TerrainActions
    {
        private @PlayerInput m_Wrapper;
        public TerrainActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_terrain_Movement;
        public InputAction @jump => m_Wrapper.m_terrain_jump;
        public InputAction @Down => m_Wrapper.m_terrain_Down;
        public InputActionMap Get() { return m_Wrapper.m_terrain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TerrainActions set) { return set.Get(); }
        public void SetCallbacks(ITerrainActions instance)
        {
            if (m_Wrapper.m_TerrainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMovement;
                @jump.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @Down.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_TerrainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public TerrainActions @terrain => new TerrainActions(this);
    public interface ITerrainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
