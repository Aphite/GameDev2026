using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                // GameManager.Instance.AddScore(); // Commented out. Collectables no longer increment score, Levels progress increment score now!
                StatsTracker.Instance?.AddItemPickup(); // Increment the item pickup count in StatsTracker
                Debug.Log("Item picked up! Items picked up: " + GameManager.Instance.score);
            }
            Destroy(gameObject);
        }
    }
}

