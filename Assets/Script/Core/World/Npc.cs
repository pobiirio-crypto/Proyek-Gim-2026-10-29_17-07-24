using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    [SerializeField] private string npcName = "Warga";
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private Sprite faceDown, faceLeft, faceRight, faceUp;

    public void Interact(PlayerInteractor who)
    {
        // PERBAIKAN: Gunakan arah hadap player, lalu balikkan (-) agar NPC menghadap player
        Vector2 arahHadapPlayer = who.movement.Facing;
        Face(-arahHadapPlayer);

        Debug.Log($"{npcName}: Halo!");
    }

    private void Face(Vector2 d) =>
        body.sprite = Mathf.Abs(d.x) > Mathf.Abs(d.y)
            ? (d.x > 0 ? faceRight : faceLeft)
            : (d.y > 0 ? faceUp : faceDown);
}