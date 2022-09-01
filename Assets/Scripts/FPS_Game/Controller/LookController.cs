using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game 
{
    public class LookController : IExecute
    {
        private Unit _unit;

        private PlayerInput playerInput;

        private InputAction look;

        public LookController(PlayerInput inputSys, Unit unit) 
        {
            _unit = unit;
            playerInput = inputSys;
            look = playerInput.Player.Look;

            OnEnable();
        }

        public void Execute()
        {
            Vector2 rot = look.ReadValue<Vector2>();
            _unit.LookRotate(rot.x, rot.y);
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

