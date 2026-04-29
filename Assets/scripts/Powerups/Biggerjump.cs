using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BiggerJump")]
public class Biggerjump : PowerupEffect
{
    public float amount;

    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.jumpForce += amount;
            Debug.Log("Biggerjump applied: +" + amount + " jump force. New jump force: " + playerMovement.jumpForce);
        }
    }
}
