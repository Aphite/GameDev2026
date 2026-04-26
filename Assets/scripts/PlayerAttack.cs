using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            Debug.Log("Player attacks!");
        }
    }

    void Attack()
    {
        // Attack Animation

        // Detect enemies in range and apply damage

        // Damage enemies
    }

}
