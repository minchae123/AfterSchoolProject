using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeManager : MonoBehaviour
{
    public GameObject scoreBoard;
    private float currentScale = 1f;
    public float scaleSpeed = 5f;
    int score;
    public GameObject cell;

    private void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard");
        scoreBoard.GetComponent<Text>().text = 0.ToString();
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), Time.deltaTime * scaleSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            currentScale *= 1.05f;
            GameManager.instance.SpawnFood();
            score += 10;
            scoreBoard.GetComponent<Text>().text = score.ToString();
            
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Virus")
        {
            Vector3 mass = transform.localScale;
            if (mass.x < 2f) return;

            transform.localScale = new Vector3(mass.x / 2, mass.y / 2, mass.x / 2);

            GameObject g = Instantiate(cell, transform.parent);
            g.transform.position = new Vector3(transform.position.x + mass.x / 2, transform.position.y + mass.y / 2, 0);


            Destroy(collision.gameObject);
            GameManager.instance.SpawnVirus();
        }

    }
}
