using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 dir;

    private void Update()
    {
        rb.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            dir.x *= -1;
            transform.localScale = new Vector3(-dir.x, 1, 1);
        }
    }
}
