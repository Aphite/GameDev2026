using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float healthRestoreAmount = 1f; // Amount of health restored by the collectible

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthRestoreAmount); // Restore health to the player
            Debug.Log("Health restored: " + healthRestoreAmount);
            Destroy(gameObject); // Destroy the collectible after it has been collected
        }
    }


}
