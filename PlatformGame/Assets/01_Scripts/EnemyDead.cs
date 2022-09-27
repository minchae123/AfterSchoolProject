using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public GameObject deadEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //kill
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}
