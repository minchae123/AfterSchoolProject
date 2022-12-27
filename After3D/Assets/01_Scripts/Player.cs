using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float pushForce;
    public float cubeMaxPositionX;

    public TouchSlider touchSlider;
    public Cube mainCube;

    private Vector3 cubePos;
    private bool isPointerDown;

    private void Start()
    {
        SpawnCube();

        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerUpEvent += OnPointerUP;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
    }

    private void Update()
    {
        mainCube.transform.position = Vector3.Lerp(
                mainCube.transform.position,
                cubePos,
                moveSpeed * Time.deltaTime
            );    
    }

    public void OnPointerDown()
    {
        isPointerDown = true;
    }

    public void OnPointerUP()
    {
        if (isPointerDown) isPointerDown = false;
        mainCube.cubeRigidbody.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);

        Invoke("SpawnNewCube", 0.3f);
    }

    public void OnPointerDrag(float x)
    {
        if (isPointerDown)
        {
            cubePos = mainCube.transform.position;
            cubePos.x = cubeMaxPositionX * x;
        }
    }

    public void OnDestroy()
    {
        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerUpEvent -= OnPointerUP;
        touchSlider.OnPointerDragEvent -= OnPointerDrag; 
    }

    public void SpawnCube()
    {
        mainCube = CubeSpawner.Instance.SpawnRandom();
        cubePos = mainCube.transform.position;
    }

    public void SpawnNewCube()
    {
        SpawnCube();
    }
}
