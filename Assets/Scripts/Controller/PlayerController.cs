using FPS_Game;
using UnityEngine;

public class PlayerController : Unit
{
    public float speed;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool _isOnGround;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        _isOnGround = controller.isGrounded;
    }

    public override void Move(Vector2 input)
    {
        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;
        controller.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
        if(_isOnGround && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (!_isOnGround) return;
        velocity.y = Mathf.Sqrt(jumpHeight * 3.0f * gravity);
    }
}
