using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth; // Maximum health value ... set to a value of 1-10!!! anything higher does not work as it is based on 10 hearts
    public float currentHealth {get; private set;} // Current health value, with a public getter and private setter to control access

    private void Awake()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health at the start
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth); // Reduce health by damage in between 0 and maxHealth

        if (currentHealth > 0)
        {
            // Player has been hurt
            Debug.Log("Player took damage! Current health: " + currentHealth);
        } else
        {
            // Plauer dead
            Debug.Log("Player died!");
            Die();
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    void Die()
    {
        Destroy(gameObject); // Remove the player from the scene
    }


    private void Update()
    {
        // // For testing purposes, space to deal damage to the player
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     TakeDamage(1f); // Take 1 damage when space is pressed
        // }
    }

}
