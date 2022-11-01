using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Rigidbody projectile;
    public Vector3 offset = Vector3.forward;
    public float velocity = 10f;

    [ContextMenu("Fire")]
    public void Fire()
    {
        var b = Instantiate(projectile, transform.TransformPoint(offset), Quaternion.identity);
        b.velocity = Vector3.forward * velocity;
    }
}
