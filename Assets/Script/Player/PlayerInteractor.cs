using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float reach = 0.6f;
    [SerializeField] private float radius = 0.3f;
    [SerializeField] private LayerMask interactableMask;
    
    // DIUBAH MENJADI PUBLIC agar bisa dibaca oleh Npc.cs
    [SerializeField] public PlayerMovement movement; 
    
    private IActionInput input;

    public void Construct(IActionInput actionInput) => input = actionInput;

    // Titik deteksi di depan player
    private Vector2 ProbePoint => (Vector2)transform.position + movement.Facing * reach;

    void Update()
    {
        if (input == null || !input.InteractPressed) return;

        // Deteksi objek di layer Interactable
        Collider2D hit = Physics2D.OverlapCircle(ProbePoint, radius, interactableMask);
        
        if (hit != null && hit.TryGetComponent(out IInteractable target))
        {
            target.Interact(this);
        }
    }
}