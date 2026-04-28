using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StatsTracker.Instance?.AddEasterEgg(); // Increment the Easter Egg count in StatsTracker
            Debug.Log("Easter Egg found! Total: " + StatsTracker.Instance?.easterEggsFound);
            Destroy(gameObject); // Remove the Easter Egg from the scene upon pickup
        }
    }
}
