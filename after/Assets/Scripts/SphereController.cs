using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float baseSize = 1f;

    private void Update()
    {
        float anim = baseSize + Mathf.Sin(Time.time * 10f) * baseSize / 7f;

        transform.localScale = Vector3.one * anim;
    }
}
