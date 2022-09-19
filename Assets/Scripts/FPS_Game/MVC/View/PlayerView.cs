using UnityEngine;

namespace FPS_Game.MVC
{
    public class PlayerView : BaseView
    {
        [Header("Movement settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity = 9.81f;
        [SerializeField] private float _jumpHeight = 3f;
        [SerializeField] private CharacterController _controller;

        [Header("Look settings")]
        [SerializeField] private Camera _camera;
        [SerializeField] private float _xSensitivity = 30f;
        [SerializeField] private float _ySensitivity = 30f;
        
        [Header("Health settings: Player")]
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private bool isInvincible = false;


        public float Speed { get => _speed; set => _speed = value; }
        public float Gravity { get => _gravity; set => _gravity = value; }
        public float JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }
        public Camera Camera { get => _camera; set => _camera = value; }
        public float XSensitivity { get => _xSensitivity; set => _xSensitivity = value; }
        public float YSensitivity { get => _ySensitivity; set => _ySensitivity = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public CharacterController Controller { get => _controller; set => _controller = value; }

        private Vector3 _loadPos = Vector3.zero;
        private Quaternion _loadRot = Quaternion.identity;


        protected override void Awake()
        {
            base.Awake();
        }

        public void LoadData(Vector3 position, Quaternion rotation)
        {
            _loadPos = position;
            _loadRot = rotation;
        }

        private void LateUpdate()
        {
            if (_loadPos != Vector3.zero)
            {
                transform.position = _loadPos;
                _loadPos = Vector3.zero;
            }
            if(_loadRot != Quaternion.identity)
            {
                transform.rotation = _loadRot;
                _loadRot = Quaternion.identity;
            }
        }
    }
}
