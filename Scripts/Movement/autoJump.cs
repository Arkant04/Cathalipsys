using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class autoJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject[] saltoHB;
    [SerializeField] bool isGrounded = false;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float distanceToGround;
    [SerializeField] Transform[] groundCheckPoints;
    float currentJumpPressTime;
    [SerializeField] int performedJumpCount;
    [SerializeField] int maxOnAirJumps = 2;
    [SerializeField] float jumpStrength = 10f;
    [SerializeField] float jumpInterval = 1f;
    private float jumpTimer;
    LayerMask Player;
    LayerMask Ground;
    public Stats Stats;
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
        Player = LayerMask.NameToLayer("Player");
        Ground = LayerMask.NameToLayer("Ground");
    }

    void Update()
    {
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0 && (isGrounded || performedJumpCount < maxOnAirJumps))
        {
            currentJumpPressTime = 0;
            performedJumpCount += 1;
            rb.velocity = new Vector2(rb.velocity.x, Stats.jumpStenghtBS);
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

        Physics2D.IgnoreLayerCollision(Player, Ground, rb.velocity.y > 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("saltoHB"))
        {
            Stats.jumpStenghtBS = Stats.jumpStenghtHB;
            
            saltoHB[0].SetActive(false);
            StartCoroutine(backToNormal(1f));
        }

        if (collision.gameObject.CompareTag("saltoHB1"))
        {
            Stats.jumpStenghtBS = Stats.jumpStenghtHB;

            saltoHB[1].SetActive(false);
            StartCoroutine(backToNormal(1f));
        }

        if (collision.gameObject.CompareTag("saltoHB2"))
        {
            Stats.jumpStenghtBS = Stats.jumpStenghtHB;

            saltoHB[2].SetActive(false);
            StartCoroutine(backToNormal(1f));
        }

        if (collision.gameObject.CompareTag("saltoHB3"))
        {
            Stats.jumpStenghtBS = Stats.jumpStenghtHB;

            saltoHB[3].SetActive(false);
            StartCoroutine(backToNormal(1f));
        }
    }



    private IEnumerator backToNormal(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Stats.jumpStenghtBS = 10f;  
    }
}