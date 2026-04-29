using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1.5f;
    public float patrolDistance = 3f; // how far left or right from their spawn point it will walk

    private Vector2 startPos;
    private int direction = 1; // 1 = right, -1 = left
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move in current direction
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Flip the patrol when limit is reached
        float dist = transform.position.x - startPos.x;
        if (dist > patrolDistance || dist < -patrolDistance)
        {
            direction *= -1;
            if (spriteRenderer != null)
                spriteRenderer.flipX = direction < 0;
        }

    }


}
