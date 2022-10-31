using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuilderScripts : MonoBehaviour
{
    public GameObject ob;
    public Vector3 spawnPoint;

    public void BuildObject()
    {
        Instantiate(ob, spawnPoint, Quaternion.identity);
    }
}
