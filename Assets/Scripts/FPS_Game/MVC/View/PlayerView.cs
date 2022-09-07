using UnityEngine;

namespace FPS_Game.MVC
{
    public class PlayerView : BaseView
    {
        [Header("Movement settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity = 9.81f;
        [SerializeField] private float _jumpHeight = 3f;

        [Header("Look settings")]
        [SerializeField] private Camera _camera;
        [SerializeField] private float _xSensitivity = 30f;
        [SerializeField] private float _ySensitivity = 30f;

        private CharacterController _controller;

        public float Speed { get => _speed; set => _speed = value; }
        public float Gravity { get => _gravity; set => _gravity = value; }
        public float JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }
        public Camera Camera { get => _camera; set => _camera = value; }
        public float XSensitivity { get => _xSensitivity; set => _xSensitivity = value; }
        public float YSensitivity { get => _ySensitivity; set => _ySensitivity = value; }
        public CharacterController Controller { get => _controller; set => _controller = value; }

        protected override void Awake()
        {
            base.Awake();
            Controller = GetComponent<CharacterController>();
        }

    }
}
