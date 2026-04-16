using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public float smoothSpeed = 5f; // The speed of the camera's movement
    public Vector3 offset = new Vector3(0, 0, -10); // The offset from the target's position
    public float lookaheadDistance = 0.4f; // Distance to look ahead in the direction of movement
    public float lookaheadSpeed =1f;

    private Vector3 currentLookahead;
    private Rigidbody2D targetRb;
    private BasicMovement move;

    void Awake()
    {
        targetRb = target.GetComponent<Rigidbody2D>();
        move = target.GetComponent<BasicMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
            return;

        if (move != null)
        {
            Vector3 targetLookahead = new Vector3(move.lastMovementDirection.x, move.lastMovementDirection.y, 0) * lookaheadDistance;
            currentLookahead = Vector3.Lerp(currentLookahead, targetLookahead, lookaheadSpeed * Time.deltaTime);
        }

        Vector3 desiredPosition = target.position + offset + currentLookahead; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // Smoothly interpolate to the desired position
        transform.position = smoothedPosition; // Update the camera's position








    }
}
