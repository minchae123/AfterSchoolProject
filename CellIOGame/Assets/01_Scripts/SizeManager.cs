using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    private float currentScale = 1f;
    public float scaleSpeed = 5f;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), Time.deltaTime * scaleSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentScale *= 1.05f;
        GameManager.instance.SpawnFood();
        Destroy(collision.gameObject);
    }
}
