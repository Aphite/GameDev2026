using UnityEngine;

public class PlayerMovement : BasicMovement
{
    public float speed = 2f;
    public float jumpForce = 10f;
    bool jumpRequested = false;

    private float coyoteTime = 0.2f; // Time after leaving a platform during which a jump is still allowed
    private float coyoteTimeCounter = 0f; // Counter to track coyote time

    Rigidbody2D rb2d;

    Animator animator;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    
    }

    void Update()
    {
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime; // Reset coyote time counter when grounded
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime; // Decrease coyote time counter when not grounded
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && coyoteTimeCounter > 0f)
        {
            jumpRequested = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            coyoteTimeCounter = 0f; // Cancel coyote time when jump key is released
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 force = Vector2.zero;

        // Not needed after adding gravity and jump
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     force.y += speed * Time.fixedDeltaTime;
        // }//end if
        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     force.y += -speed * Time.fixedDeltaTime;
        // }//end if

        if (Input.GetKey(KeyCode.RightArrow))
        {
            force.x += speed * Time.fixedDeltaTime;
        }//end if
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force.x += -speed * Time.fixedDeltaTime;
        }//end if

        // SPEED BOOST
        if (Input.GetKey(KeyCode.LeftShift))
        {
            force *= 2f; // Increase speed by 100% when Left Shift is held
        }

        if (jumpRequested)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpRequested = false;
        }



        bool isMoving = force != Vector2.zero;
        animator.SetBool("IsWalking", isMoving);

        // Flip character based on movement direction
        if (force.x < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
        else if (force.x > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }

        setLastMovementDirection(force);
        
        rb2d.linearVelocity = new Vector2(force.x / Time.fixedDeltaTime, rb2d.linearVelocity.y);

    }//end Update

    
}//end class
