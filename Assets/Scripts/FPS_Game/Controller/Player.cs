using System.Collections;
using UnityEngine;

namespace FPS_Game 
{
    public class Player : Unit
    {
        [Header("Movement settings")]
        public float speed;
        public float gravity = 9.81f;
        public float jumpHeight = 3f;

        [Header("Look settings")]
        public Camera playerCamera;
        public float xSensitivity = 30f;
        public float ySensitivity = 30f;

        [Header("Health settings: Player")]
        public bool isInvincible = false;

        private CharacterController controller;
        private Vector3 velocity;
        private bool _isOnGround;
        private float _xRotation = 0f;
        private float _prevSpeed;

        public override void Awake()
        {
            base.Awake();
            CurrentSpeed = speed;
            controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public override void Move(Vector2 input)
        {
            _isOnGround = controller.isGrounded;

            Vector3 direction = Vector3.zero;
            direction.x = input.x;
            direction.z = input.y;
            controller.Move(transform.TransformDirection(direction) * CurrentSpeed * Time.deltaTime);

            velocity.y -= gravity * Time.deltaTime;
            if (_isOnGround && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            controller.Move(velocity * Time.deltaTime);
        }

        public override void Jump()
        {
            if (!_isOnGround) return;
            velocity.y = Mathf.Sqrt(jumpHeight * 3.0f * gravity);
        }

        public override void Rotate(float x, float y)
        {
            float mouseX = x;
            float mouseY = y;

            _xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

            playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }

        public void SpeedChange(float speedScaler, float timeDelay) 
        {
            _prevSpeed = CurrentSpeed;
            CurrentSpeed *= speedScaler;
            StartCoroutine(SpeedChangeDelay(timeDelay));
        }

        IEnumerator SpeedChangeDelay(float time) 
        {
            yield return new WaitForSeconds(time);
            CurrentSpeed = _prevSpeed;
        }

        public void Heal(float healValue)
        {
            CurrentHealth += healValue;
        }

        public void TakeDamage(float damage)
        {
            if (isInvincible)
                return;

            CurrentHealth -= damage;
        }

    }
}

