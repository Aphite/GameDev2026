using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Attackbuff")]
public class Attackbuff : PowerupEffect
{
    public int amount;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<PlayerAttack>().damageAmount += amount; 
    }

}
