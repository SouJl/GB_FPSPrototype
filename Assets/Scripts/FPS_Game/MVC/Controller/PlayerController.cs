using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game.MVC
{
    public class PlayerController : IExecute
    {
        private Player playerModel;
        private PlayerInput _iputSystem;

        private InputAction _move;
        private InputAction _jump;

        public PlayerController()
        {

        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
