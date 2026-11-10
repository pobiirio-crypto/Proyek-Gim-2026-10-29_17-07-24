using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private IMoveInput input;

    public void Construct(IMoveInput moveInput) => input = moveInput;

    void Update()
    {
        if (input == null) return;

        Vector2 move = input.Move;
        animator.SetFloat("VelocityX", move.x);
        animator.SetFloat("VelocityY", move.y);
        animator.SetBool("IsRunning", input.IsRunning);

        // Update facing direction
        if (move.x > 0.1f) animator.SetFloat("FacingX", 1f);
        else if (move.x < -0.1f) animator.SetFloat("FacingX", -1f);

        if (move.y > 0.1f) animator.SetFloat("FacingY", 1f);
        else if (move.y < -0.1f) animator.SetFloat("FacingY", -1f);
    }
}