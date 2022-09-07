using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class PlayerModel : AbstractUnitModel
    {
        private CharacterController _controller;

        public PlayerModel(PlayerView view) 
        {
            Transform = view.Transform;
            CurrentSpeed = view.Speed;
            _controller = view.Controller;
        }

        public override void Move(Vector2 input)
        {
            throw new NotImplementedException();
        }
    }
}
