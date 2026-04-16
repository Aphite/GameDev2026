using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // change color of goals to green when the player wins
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.playerWon)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.green;
            }
        }
    }
}
