using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Vector2 lastMovementDirection = Vector2.zero; // Store the last movement direction
    public float groundCheckDistance = 0.1f; // Distance to check for ground

    public void setLastMovementDirection(Vector2 movement)
    {
        if (movement != Vector2.zero)
            lastMovementDirection = movement.normalized; // Update the last movement direction if it's not zero
        else
            lastMovementDirection = Vector2.zero; // Reset to zero if there's no movement
    }

    public bool IsGrounded()
    {
        // Check if the player is grounded using a raycast
        Collider2D collider = GetComponent<Collider2D>();
        Vector2 rayStart = new Vector2(collider.bounds.center.x, collider.bounds.min.y - 0.01f);
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, groundCheckDistance);
        bool grounded = hit.collider != null && hit.collider.gameObject != gameObject; // Ensure we don't detect ourselves
        Debug.DrawRay(rayStart, Vector2.down * groundCheckDistance, grounded ? Color.green : Color.red); // Visualize the raycast
        Debug.Log("IsGrounded: " + grounded);
        return grounded;
    }

}
