using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private SpriteRenderer spriteRenderer;
    private float defaultAttackPointX;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (attackPoint != null)
        {
            defaultAttackPointX = attackPoint.localPosition.x;
        }
    }

    void Update()
    {
        UpdateAttackPointDirection(); // Ensure the attack point follows the player's facing direction

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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            // Here you would typically call a method on the enemy to apply damage, e.g.:
            // enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }

    void UpdateAttackPointDirection()
    {
        if (attackPoint == null || spriteRenderer == null)
            return;

        float x = Mathf.Abs(defaultAttackPointX);
        if (spriteRenderer.flipX)
        {
            x = -x;
        }

        attackPoint.localPosition = new Vector3(x, attackPoint.localPosition.y, attackPoint.localPosition.z); // Update the attack point's local position based on the player's facing direction
    }

    // Visualize the attack range in the editor for debugging purposes
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
