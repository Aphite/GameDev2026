using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;

    int currentHealth;
    
    
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " takes " + damage + " damage. Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Remove the enemy from the scene
    }
    
}
