using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    public TMP_Text[] numbersLists;
    public Color cubleColor;
    public int cubeNumber;
    public Rigidbody cubeRigidbody;
    public MeshRenderer cubeMeshRenderer;

    private void Awake()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor(Color co)
    {
        cubeMeshRenderer.material.color = co;
    }

    public void SetNumber(int num)
    {
        cubeNumber = num;
        for(int i = 0; i < 6; i++)
        {
            numbersLists[i].text = num.ToString();
        }
    }
}
