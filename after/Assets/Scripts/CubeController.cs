using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    void Start()
    {
        GenerateColor();
    }

    public void GenerateColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }
}
