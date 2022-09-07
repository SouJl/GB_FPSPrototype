﻿using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class PlayerModel : AbstractUnitModel
    {
        private float _gravity;
        private float _jumpHeight;

        private CharacterController _controller;
        private Vector3 velocity;
        private bool _isOnGround;
        private float _prevSpeed;


        public float Gravity { get => _gravity; private set => _gravity = value; }
        public float JumpHeight { get => _jumpHeight; private set => _jumpHeight = value; }

        public event Action<bool> GameOver = delegate (bool state) { };

        public PlayerModel(PlayerView view) 
        {
            Transform = view.Transform;
            
            MaxHealth = view.MaxHealth;
            CurrentHealth = MaxHealth;
            CurrentSpeed = view.Speed;

            Gravity = view.Gravity;
            JumpHeight = view.JumpHeight;

            _controller = view.Controller;
        }

        public override void Move(Vector2 input)
        {
            _isOnGround = _controller.isGrounded;

            Vector3 direction = Vector3.zero;
            direction.x = input.x;
            direction.z = input.y;
            _controller.Move(Transform.TransformDirection(direction) * CurrentSpeed * Time.deltaTime);

            velocity.y -= Gravity * Time.deltaTime;
            if (_isOnGround && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            _controller.Move(velocity * Time.deltaTime);
        }

        public void Jump()
        {
            if (!_isOnGround) return;
            velocity.y = Mathf.Sqrt(JumpHeight * 3.0f * Gravity);
        }

        public void Heal(float value)
        {
            CurrentHealth += value;
        }

        public void TakeDamage(float value)
        { 
            CurrentHealth -= value;
            if (CurrentHealth <= 0) GameOver?.Invoke(false);
        }
    }
}
