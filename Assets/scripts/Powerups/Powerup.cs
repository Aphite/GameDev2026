using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect effect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect.ApplyEffect(collision.gameObject);
            Debug.Log("Powerup applied: " + effect.name);
            Destroy(gameObject); // Destroy the powerup after applying its effect
        }
    }
}
