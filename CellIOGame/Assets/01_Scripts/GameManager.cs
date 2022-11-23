using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject foodPrefab;
    
    [Header("�÷��̾� ����")]
    public GameObject playerPrefab;
    public GameObject camm;

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
        Vector3 spawnPos = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject food = Instantiate(foodPrefab, spawnPos, Quaternion.identity);

        food.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.9f, 1);
    }

    public void SpawnPlayer()
    {
        Vector3 spawnUserPos = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _player =  PhotonNetwork.Instantiate(playerPrefab.name, spawnUserPos, Quaternion.identity);

        camm.SetActive(true);
        camm.GetComponent<SmoothCamera>().target = _player.transform;

        _player.GetComponent<SizeManager>().enabled = true;
        _player.GetComponent<Movement>().enabled = true;
    }
}
