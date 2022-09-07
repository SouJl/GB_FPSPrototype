using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game.MVC
{
    public class PlayerController : IExecute
    {
        private PlayerModel playerModel;
        private PlayerInput _iputSystem;

        private InputAction _move;
        private InputAction _jump;

        public PlayerController(PlayerModel model, PlayerInput inputSys)
        {
            playerModel = model;
            _iputSystem = inputSys;

            _move = _iputSystem.Player.Movement;
            _jump = _iputSystem.Player.Jump;
            _jump.performed += jmp => playerModel.Jump();

            OnEnable();
        }

        public void Execute()
        {
            playerModel.Move(_move.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _move.Enable();
            _jump.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
            _jump.Disable();
        }

        ~PlayerController() => OnDisable();
    }
}
