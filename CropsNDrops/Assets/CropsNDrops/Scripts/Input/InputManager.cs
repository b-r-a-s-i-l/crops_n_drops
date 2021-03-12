using UnityEngine;
using UnityEngine.InputSystem;

namespace CropsNDrops.Scripts.Input
{
    public class InputManager : MonoBehaviour
    {
        private TouchControls _touchControls = default;
        private bool _isPressed = default;
        
        public delegate void StartTouchEvent(Vector2 position);
        public event StartTouchEvent OnStartTouch;
        
        public delegate void EndTouchEvent(Vector2 position);
        public event EndTouchEvent OnEndTouch;
        
        public delegate void DragEvent(Vector2 position);
        public event DragEvent OnDragTouch;

        private void Awake()
        {
            _touchControls = new TouchControls();
        }
        
        private void OnEnable()
        {
            _touchControls.Enable();
        }

        private void Start()
        {
            _touchControls.TouchMap.TouchPress.started += StartPress;
            _touchControls.TouchMap.TouchPress.canceled += EndPress;
        }
        
        private void OnDisable()
        {
            _touchControls.Disable();
        }

        private void OnDestroy()
        {
            _touchControls.TouchMap.TouchPress.started -= StartPress;
            _touchControls.TouchMap.TouchPress.canceled -= EndPress;
        }

        private void StartPress(InputAction.CallbackContext context)
        {
            _isPressed = true;
            OnStartTouch?.Invoke(_touchControls.TouchMap.TouchPosition.ReadValue<Vector2>());
        }
        
        private void EndPress(InputAction.CallbackContext context)
        {
            OnEndTouch?.Invoke(_touchControls.TouchMap.TouchPosition.ReadValue<Vector2>());
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed)
            {
                OnDragTouch?.Invoke(_touchControls.TouchMap.TouchPosition.ReadValue<Vector2>());
            }
        }
    }
}
