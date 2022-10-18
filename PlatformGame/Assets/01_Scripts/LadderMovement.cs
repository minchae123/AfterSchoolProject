using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float speed = 8f;
    private bool isLadder;
    private bool isClimb;

    private float vertical;

    [SerializeField] private Rigidbody2D rb;


    private void FixedUpdate()
    {
        if (isClimb)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimb = true;
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
            isClimb = false;
        }
    }
}
