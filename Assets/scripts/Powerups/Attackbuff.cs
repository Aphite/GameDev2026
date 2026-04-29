using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Attackbuff")]
public class Attackbuff : PowerupEffect
{
    public int amount;

    public override void ApplyEffect(GameObject player)
    {
        PlayerAttack playerAttack = player.GetComponent<PlayerAttack>();
        playerAttack.damageAmount += amount;
        Debug.Log("Attackbuff applied: +" + amount + " damage. New damage: " + playerAttack.damageAmount);
    }

}
