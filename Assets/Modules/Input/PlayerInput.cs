using System;
using UnityEngine;

namespace Modules.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnPointerDown;
        public event Action OnPointerUp;
        public event Action<Vector2> OnPointerMoved;
        public event Action<Vector2> OnPointerDragged;

        private Vector2 _prevMousePos;

        private bool _pointerDownState = false;
        private bool _prevPointerDownState = false;

        private void Start()
        {
            _prevMousePos = UnityEngine.Input.mousePosition;
        }

        private void Update()
        {
            _prevPointerDownState = _pointerDownState;
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                OnPointerDown?.Invoke();
                _pointerDownState = true;
            }
            
            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                OnPointerUp?.Invoke();
                _pointerDownState = false;
            }

            Vector2 mousePosition = UnityEngine.Input.mousePosition;
            Vector2 posDifference = mousePosition - _prevMousePos;
            if (posDifference.magnitude > 0f)
            {
                OnPointerMoved?.Invoke(posDifference);
                _prevMousePos = mousePosition;

                if (_prevPointerDownState && _pointerDownState)
                {
                    OnPointerDragged?.Invoke(posDifference);
                }
            }
        }
    }
}