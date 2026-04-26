using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Speedbuff")]
public class Speedbuff : PowerupEffect
{
    public float amount;

    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.speed += amount;
        }
    }
}
