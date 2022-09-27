using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthPoint = 5;

    public Image[] heart;
    public Sprite emptyH;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("�ƾ�");
            StartCoroutine(KnockBack(0.2f, 30));
            Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        healthPoint--;
        heart[healthPoint].sprite = emptyH;
    }

    IEnumerator KnockBack(float knockBackTime, float knockBackPower)
    {
        float timer = 0;
        while (timer < knockBackTime)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector2(transform.position.x * -50f, transform.position.y + knockBackPower));
        }
        yield return 0;
    }

}
