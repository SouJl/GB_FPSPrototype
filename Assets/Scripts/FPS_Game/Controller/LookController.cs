using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game 
{
    public class LookController : IExecute
    {
        private IRotation _rotator;

        private PlayerInput playerInput;

        private InputAction look;

        public LookController(PlayerInput inputSys, IRotation rotator) 
        {
            _rotator = rotator;
            playerInput = inputSys;
            look = playerInput.Player.Look;

            OnEnable();
        }

        public void Update()
        {
            Vector2 rot = look.ReadValue<Vector2>();
            _rotator.Rotate(rot.x, rot.y);
        }

        private void OnEnable()
        {
            look.Enable();
        }

        private void OnDisable()
        {
            look.Disable();
        }

        ~LookController() => OnDisable();
    }
}

