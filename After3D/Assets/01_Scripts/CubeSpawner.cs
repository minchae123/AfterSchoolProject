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

    public int maxCubeNumber;
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

    public void AddCubeToQueue()
    {
        Cube cube = Instantiate(cubePrefab, defaultSpawnPos, Quaternion.identity).GetComponent<Cube>();
        cube.gameObject.SetActive(false);
        cubeQueue.Enqueue(cube);
    }

    public int GenerateRandomNumber()
    {
        return (int)Mathf.Pow(2, Random.Range(1, 6));
    }

    public Color GetColor(int num)
    {
        return cubeColors[(int)(Mathf.Log(num) / Mathf.Log(2) - 1)];
    }

    public Cube Spawn(int num, Vector3 pos)
    {
        if(cubeQueue.Count == 0)
        {
            if (autoQueueGrow)
            {
                cubesQueueCapacity++;
                AddCubeToQueue();
            }
            else
            {
                Debug.LogError("empty");
                return null;
            }
        }

        Cube cube = cubeQueue.Dequeue();
        cube.transform.position = pos;
        cube.SetNumber(num);
        cube.gameObject.SetActive(true);
        cube.SetColor(GetColor(num));
        return cube;
    }

    public Cube SpawnRandom()
    {
        return Spawn(GenerateRandomNumber(), defaultSpawnPos);
    }

    public void DestroyCube(Cube cube)
    {
        cube.cubeRigidbody.velocity = Vector3.zero;
        cube.cubeRigidbody.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.gameObject.SetActive(false);
        cubeQueue.Enqueue(cube);
    }
}
