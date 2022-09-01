using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game 
{
    public class MoveController: IExecute
    {
        private Unit _unit;

        private PlayerInput playerInput;

        private InputAction move;
        private InputAction jump;

        public MoveController(PlayerInput inputSys, Unit unit) 
        {
            _unit = unit;

            playerInput = inputSys;
            move = playerInput.Player.Movement;
            jump = playerInput.Player.Jump;
            jump.performed += jmp => _unit.Jump();

            OnEnable();
        }

        public void Execute()
        {
            _unit.Move(move.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            move.Enable();
            jump.Enable();
        }

        private void OnDisable()
        {
            move.Disable();
            jump.Disable();
        }

        ~MoveController() => OnDisable();
    }
}

