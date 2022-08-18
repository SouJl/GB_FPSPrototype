using UnityEngine;

namespace FPS_Game 
{
    public class Player : Unit
    {
        public float speed;
        public float gravity = 9.81f;
        public float jumpHeight = 3f;

        private CharacterController controller;
        private Vector3 velocity;
        private bool _isOnGround;

        public override void Awake()
        {
            base.Awake();
            controller = GetComponent<CharacterController>();
            Health = 100;
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
    }
}

