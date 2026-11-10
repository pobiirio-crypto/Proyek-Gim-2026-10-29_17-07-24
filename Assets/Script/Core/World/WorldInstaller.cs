using UnityEngine;

public class WorldInstaller : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    // P2 hanya menerima 1 parameter
    public void Install(IMoveInput moveInput)
    {
        player.Construct(moveInput);
    }
}