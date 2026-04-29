using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Healthbuff")]
public class Healthbuff : PowerupEffect
{
    public float amount;

    public override void ApplyEffect(GameObject player)
    {
        Health health = player.GetComponent<Health>();
        health.currentHealth += amount;
        Debug.Log("Healthbuff applied: +" + amount + " health. New health: " + health.currentHealth);
    }
}
