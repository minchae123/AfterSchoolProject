using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallinTIle : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDealy = 2f;

    [SerializeField] Rigidbody2D tb;

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        tb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDealy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
}
