using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] bool isGrounded = false;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float distanceToGround;
    [SerializeField] Transform[] groundCheckPoints;
    float currentJumpPressTime;
    [SerializeField] int performedJumpCount;
    [SerializeField] int maxOnAirJumps = 1; 
    [SerializeField] float jumpStrength = 10f; 
    [SerializeField] float jumpInterval = 1f; 
    private float jumpTimer;


    [SerializeField] float upGravity = 1f;
    [SerializeField] float downGravity = 2f;
    [SerializeField] float peakGravity = 0.5f;
    [SerializeField] float yVelocityLowGravityThreshold = 0.1f;

    float timeOnAir;

    void Start()
    {
        performedJumpCount = 0;
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval;
    }

    void Update()
    {
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0 && (isGrounded || performedJumpCount < maxOnAirJumps))
        {
            currentJumpPressTime = 0;
            performedJumpCount += 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            jumpTimer = jumpInterval;
        }

        if (rb.velocity.y < yVelocityLowGravityThreshold && rb.velocity.y > -yVelocityLowGravityThreshold)
        {
            rb.gravityScale = peakGravity;
        }
        else if (rb.velocity.y > 0)
        {
            rb.gravityScale = upGravity;
        }
        else
        {
            rb.gravityScale = downGravity;
        }


        isGrounded = false;
        for (int i = 0; i < groundCheckPoints.Length; i++)
        {
            bool hit = Physics2D.Raycast(
                groundCheckPoints[i].position,
                Vector2.down,
                distanceToGround,
                groundLayer);

            if (hit)
            {
                timeOnAir = 0;
                isGrounded = true;
                performedJumpCount = 0;
                rb.gravityScale = upGravity;
                break;
            }
        }


        if (!isGrounded)
        {
            timeOnAir += Time.deltaTime;
        }
    }
}
