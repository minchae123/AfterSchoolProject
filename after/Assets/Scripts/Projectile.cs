using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;

    public void Reset()
    {
        rb = GetComponent<Rigidbody>();
    }
}
