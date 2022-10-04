using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBlock : MonoBehaviour
{
    PlatformEffector2D platformEffector2D;
    Movement movement = null;

    private void Awake()
    {
        platformEffector2D = GetComponent<PlatformEffector2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            movement = collision.gameObject.GetComponent<Movement>();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (movement == null)
        {
            return;
        }
        if (movement.downPressed)
        {
            platformEffector2D.rotationalOffset = 180;
            movement = null;
        }
        /*else
        {
            platformEffector2D.rotationalOffset = 0;
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        movement = null;
        platformEffector2D.rotationalOffset = 0;
    }
}
