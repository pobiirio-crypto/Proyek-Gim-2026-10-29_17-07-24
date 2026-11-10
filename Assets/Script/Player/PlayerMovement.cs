using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private Rigidbody2D rb;
    private IMoveInput input;
    private Vector2 velocity;

    // Property public untuk dibaca Animator
    public Vector2 Velocity => velocity;
    public bool IsRunning => input != null && input.IsRunning;
    public Vector2 Facing => input != null ? input.Move : Vector2.zero;

    public void Construct(IMoveInput moveInput) => input = moveInput;

    void Update()
    {
        if (input == null) return;
        float speed = input.IsRunning ? config.RunSpeed : config.WalkSpeed;
        velocity = input.Move * speed;
    }

    void FixedUpdate() => rb.linearVelocity = velocity;
}