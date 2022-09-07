using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game.MVC
{
    public class CameraController:IExecute
    {
        private Transform _targetTransform;
        private Transform _cameratransform;

        private PlayerInput _inputSystem;
        private InputAction _look;

        private float _xSensitivity;
        private float _ySensitivity;
        private float _xRotation;

        public CameraController(Transform target, Transform camera, PlayerInput inputSys)
        {
            _targetTransform = target;
            _cameratransform = camera;
            _inputSystem = inputSys;
            _look = _inputSystem.Player.Look;
            OnEnable();
        }

        public CameraController(Transform target, Transform camera, PlayerInput inputSys, (float x, float y) sensitivity)
        {
            _targetTransform = target;
            _cameratransform = camera;
            _inputSystem = inputSys;
            _look = _inputSystem.Player.Look;

            _xSensitivity = sensitivity.x;
            _ySensitivity = sensitivity.y;
            OnEnable();
        }

        public void Execute()
        {
            Rotation(_look.ReadValue<Vector2>());
        }

        private void Rotation(Vector2 rotation)
        {
            float mouseX = rotation.x;
            float mouseY = rotation.y;

            _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

            _cameratransform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            _targetTransform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
        }

        private void OnEnable()
        {
            _look.Enable();
        }

        private void OnDisable()
        {
            _look.Disable();
        }

        ~CameraController() => OnDisable();
    }
}
