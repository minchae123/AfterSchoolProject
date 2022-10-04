using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private float jumpPower = 7f;
    private bool doubleJump;

    private float coyoteTime = 0.2f;
    private float coyoteTimerCounter;

    Vector2 movedir;
    Vector2 velocity;
    Vector2 playerMovement;

    public Rigidbody2D rb;
    public float gravity;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public Animator animator;
    public bool downPressed;

    private void Update()
    {
        movedir.x = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            coyoteTimerCounter = coyoteTime;
        }
        else
        {
            coyoteTimerCounter -= Time.deltaTime;
        }

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (IsGrounded() && velocity.y <= 0)
        {
            //velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            downPressed = true;
        }
        else
        {
            downPressed = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
           if (coyoteTimerCounter > 0 || doubleJump)
           {
                //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                Debug.Log(velocity.y);
                doubleJump = !doubleJump;
                }
           }

            //velocity.y += gravity * Time.deltaTime;
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimerCounter = 0;
            }
            //playerMovement = new Vector2(movedir.x * (speed * 10f), velocity.y);

            Flip();
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movedir.x * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround);
    }

    private void Flip()
    {
        if(movedir.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (movedir.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        animator.SetFloat("Move", Mathf.Abs(movedir.x));
    }
}