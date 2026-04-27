using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore();
                StatsTracker.Instance?.AddItemPickup(); // Increment the item pickup count in StatsTracker
                Debug.Log("Collectible picked up! Pickup Score: " + GameManager.Instance.score);
            }
            Destroy(gameObject);
        }
    }
}

