using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Healthbuff")]
public class Healthbuff : PowerupEffect
{
    public float amount;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<Health>().currentHealth += amount;
    }
}
