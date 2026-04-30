using UnityEngine;

public class EnemyAggressive : MonoBehaviour
{
    
    public float speed = 2.5f;
    public float detectionRange = 6f;  // Distance at which the enemy notices the player
    public float attackRange = 0.8f;   // Distance at which the enemy can hit the player
    public float attackDamage = 1f;
    public float attackCooldown = 1.2f; // Seconds between attacks
 
    private Transform player;
    private float attackTimer = 0f;
    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;
 
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Find the player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }
 
    void Update()
    {
        if (player == null) return;
 
        attackTimer -= Time.deltaTime;
 
        float dist = Vector2.Distance(transform.position, player.position);
        playerInRange = dist <= detectionRange;
 
        if (playerInRange)
        {
            // Chase the player
            Vector2 dir = (player.position - transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime);
 
            // Flip sprite to face the player
            if (spriteRenderer != null)
                spriteRenderer.flipX = dir.x < 0;
 
            // Attack if close enough and cooldown is ready
            if (dist <= attackRange && attackTimer <= 0f)
            {
                Health playerHealth = player.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage);
                    Debug.Log("Enemy attacked player for " + attackDamage + " damage.");
                }
                attackTimer = attackCooldown;
            }
        }
    }
 
    // Visual debug: shows detection and attack ranges in the Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
