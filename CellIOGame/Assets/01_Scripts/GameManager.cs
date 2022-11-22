using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;

    public Vector2 xRange;
    public Vector2 yRange;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y));
        GameObject food = Instantiate(foodPrefab, spawnPos, Quaternion.identity);

        food.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.9f, 1);
    }
}
