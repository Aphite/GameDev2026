using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb2d;

    void Update()
    {
        
        vertical = Input.GetAxis("Vertical"); // Get vertical input (up/down arrow keys)

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb2d.gravityScale = 0f; // Disable gravity while climbing
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, vertical * speed);
        } else
        {
            rb2d.gravityScale = 3f; // Re-enable gravity when not climbing
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

}
