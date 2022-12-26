using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner Instance;
    Queue<Cube> cubeQueue = new Queue<Cube>();

    public int cubesQueueCapacity = 20;
    public bool autoQueueGrow = true;

    public GameObject cubePrefab;
    public Color[] cubeColors;

    private int maxCubeNumber;
    private int maxPower = 12;

    private Vector3 defaultSpawnPos;

    private void Awake()
    {
        Instance = this;
        defaultSpawnPos = transform.position;
        maxCubeNumber = (int)Mathf.Pow(2, maxPower);
    }

    public void InitCubeQueue()
    {
        for(int i = 0; i < cubesQueueCapacity; i++)
        {
            // 큐브를 생성해서 큐에 쌓아두기
        }
    }
}
