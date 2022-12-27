using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    static int staticId = 0;
    public int CubeId;

    public TMP_Text[] numbersLists;
    public Color cubleColor;
    public int cubeNumber;
    public Rigidbody cubeRigidbody;
    public MeshRenderer cubeMeshRenderer;

    private void Awake()
    {
        CubeId = staticId++;
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor(Color co)
    {
        cubleColor = co;
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
