using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerLook playerLook;

    private PlayerInput playerInput;

    private InputAction move;
    private InputAction jump;
    private InputAction look;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerLook = GetComponent<PlayerLook>();
        
        playerInput = new PlayerInput();       
        move = playerInput.Player.Movement;
        jump = playerInput.Player.Jump;
        look = playerInput.Player.Look;

        jump.performed += jmp => playerController.Jump();
    }

    private void FixedUpdate()
    {
        if (!playerController) return;
        playerController.Move(move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        if (!playerLook) return;
        Vector2 rot = look.ReadValue<Vector2>();
        playerLook.Rotate(rot.x, rot.y);
    }

    private void OnEnable()
    {
        move.Enable();
        jump.Enable();
        look.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        look.Disable();
    }
}
