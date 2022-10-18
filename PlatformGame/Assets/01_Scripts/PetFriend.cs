using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFriend : MonoBehaviour
{
    public float speed;

    Transform player;
    public float distance;
    Animator animator;
    public LayerMask groundLayer;
    public float jumpPower;
    public Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(9, 10);
    }
    private void Update()
    {
        if(Mathf.Abs(transform.position.x - player.position.x) > distance)
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            animator.SetBool("Move", true);
            DirectionCheck();

            Physics2D.Raycast(transform.position, new Vector2(1,1), 2.5f,groundLayer);
            
             RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * -1f, 0.5f);
             RaycastHit2D hit2 = Physics2D.Raycast(transform.position, new Vector2(1 * DirectionCheck(),1), 0.5f);

            if(player.position.y - transform.position.y <=0)
            {
                hit2 = new RaycastHit2D();
            }

            if (hit || hit2)
            {
                rb.velocity = Vector2.up * jumpPower;
            }
        }
        else
        {
            animator.SetBool("Move", false);
        }

    }

    float DirectionCheck()
    {
        if (transform.position.x - player.transform.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            return 1;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            return 0;
        }
    }
}
