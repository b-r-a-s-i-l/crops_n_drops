// GENERATED AUTOMATICALLY FROM 'Assets/CropsNDrops/Scripts/Input/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""TouchMap"",
            ""id"": ""8ff91b3d-7ba9-4f99-b654-7766ebb0b1e6"",
            ""actions"": [
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""9f30f4e1-de20-46e8-921a-520277366706"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47951bb8-1fc5-49ab-a05e-e699c60f7fb0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c23019ee-4497-4a3f-8137-718b57e37b77"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f22ced40-580f-4bf2-8451-33599f071eb2"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchMap
        m_TouchMap = asset.FindActionMap("TouchMap", throwIfNotFound: true);
        m_TouchMap_TouchPress = m_TouchMap.FindAction("TouchPress", throwIfNotFound: true);
        m_TouchMap_TouchPosition = m_TouchMap.FindAction("TouchPosition", throwIfNotFound: true);
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

    // TouchMap
    private readonly InputActionMap m_TouchMap;
    private ITouchMapActions m_TouchMapActionsCallbackInterface;
    private readonly InputAction m_TouchMap_TouchPress;
    private readonly InputAction m_TouchMap_TouchPosition;
    public struct TouchMapActions
    {
        private @TouchControls m_Wrapper;
        public TouchMapActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPress => m_Wrapper.m_TouchMap_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_TouchMap_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_TouchMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchMapActions set) { return set.Get(); }
        public void SetCallbacks(ITouchMapActions instance)
        {
            if (m_Wrapper.m_TouchMapActionsCallbackInterface != null)
            {
                @TouchPress.started -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_TouchMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public TouchMapActions @TouchMap => new TouchMapActions(this);
    public interface ITouchMapActions
    {
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
