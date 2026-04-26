using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public Animator animator;
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
        animator.SetTrigger("attack");
        // Detect enemies in range and apply damage

        // Damage enemies
    }

}
