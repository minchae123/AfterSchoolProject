using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] tetroMinoes;

    public static int score;
    public Text scoreText;

    public Vector3[] spawnPositioins;
    public GameObject gameOverPanel;

    public Queue<GameObject> nextTetrominoes;


    private void Start()
    {
        nextTetrominoes = new Queue<GameObject>();
        for (int i = 0; i < spawnPositioins.Length; i++)
        {
            GenerateNext(i);
        }
        NewTetroMino();
    }

    private void Update()
    {
        if (scoreText) scoreText.text = $"Score : {score}";
    }

    public void GenerateNext(int i)
    {
        GameObject t = Instantiate(tetroMinoes[Random.Range(0, tetroMinoes.Length)], spawnPositioins[i], Quaternion.identity);
        t.GetComponent<TetrisBlock>().gameOverPanel = gameOverPanel;
        t.GetComponent<TetrisBlock>().enabled = false;
        nextTetrominoes.Enqueue(t);
    }

    public void NewTetroMino()
    {
        //Instantiate(tetroMinoes[Random.Range(0, tetroMinoes.Length)], transform.position, Quaternion.identity);
        
        GameObject t = nextTetrominoes.Dequeue();
        t.transform.position = transform.position;
        t.GetComponent<TetrisBlock>().gameOverPanel = gameOverPanel;
        t.GetComponent<TetrisBlock>().enabled = true;

        GenerateNext(spawnPositioins.Length - 1);
        MoveSpawnerPos();
    }

    public void MoveSpawnerPos()
    {
        for (int i = 0; i < spawnPositioins.Length; i++)
        {
            GameObject t = nextTetrominoes.Dequeue();
            t.transform.position = spawnPositioins[i];
            nextTetrominoes.Enqueue(t);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
