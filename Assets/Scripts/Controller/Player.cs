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

        private CharacterController controller;
        private Vector3 velocity;
        private bool _isOnGround;
        private float xRotation = 0f;

        public override void Awake()
        {
            base.Awake();
            controller = GetComponent<CharacterController>();
            Health = 100;

            Cursor.lockState = CursorLockMode.Locked;
        }

        public override void Move(Vector2 input)
        {
            _isOnGround = controller.isGrounded;

            Vector3 direction = Vector3.zero;
            direction.x = input.x;
            direction.z = input.y;
            controller.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);

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

            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }
    }
}

