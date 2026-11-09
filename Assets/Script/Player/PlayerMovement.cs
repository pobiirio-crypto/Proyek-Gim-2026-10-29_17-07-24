
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.75f;
    [SerializeField] private Rigidbody2D rb;

    private InputAction moveAction;
    private InputAction sprintAction;
    private Vector2 moveInput;
    private bool isSprinting;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        isSprinting = sprintAction != null && sprintAction.IsPressed();
    }

    void FixedUpdate()
    {
        float currentSpeed = isSprinting ? moveSpeed * 1.6f : moveSpeed;

        rb.linearVelocity = moveInput * currentSpeed;
    }
}
