using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float speed;

    private void Update()
    {
        Vector2 input = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(input);
        worldPos.z = 0f;

        transform.position = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);
    }
}
