using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damageAmount = 25f; // the damage the spike will deal to the player
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthBar healthBar = collision.gameObject.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                Debug.Log("Player hit spikes! Damage taken: " + damageAmount);
                healthBar.TakeDamage(damageAmount); // the damage the spike will deal to the player
            }
        }
    }
}
