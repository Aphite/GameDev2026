using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    public Sprite[] frames;  // Array of animation frames
    public float frameRate = 0.1f;  // Time between frames
    
    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;  // Loop through frames
            spriteRenderer.sprite = frames[currentFrame];  // Update the sprite
        }
    }//end method
}//end class