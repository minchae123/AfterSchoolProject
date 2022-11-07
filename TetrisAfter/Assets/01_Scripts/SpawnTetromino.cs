using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] tetroMinoes;

    private void Start()
    {
        NewTetroMino();
    }

    public void NewTetroMino()
    {
        Instantiate(tetroMinoes[Random.Range(0, tetroMinoes.Length)], transform.position, Quaternion.identity);
    }
}
