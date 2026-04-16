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
                Debug.Log("Coin picked up! Total Score: " + GameManager.Instance.score);
            }
            Destroy(gameObject);
        }
    }
}

