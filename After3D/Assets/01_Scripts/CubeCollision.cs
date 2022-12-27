using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    Cube cube;
    private void Awake()
    {
        cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Cube otherCube = collision.gameObject.GetComponent<Cube>();
        if(otherCube != null && cube.CubeId > otherCube.CubeId)
        {
            if(cube.cubeNumber == otherCube.cubeNumber)
            {
                Debug.Log("HIT!");
                Vector3 contactPoint = collision.contacts[0].point;
                if(otherCube.cubeNumber < CubeSpawner.Instance.maxCubeNumber)
                {
                    Cube newCube = CubeSpawner.Instance.Spawn(cube.cubeNumber * 2, contactPoint + Vector3.up * 1.5f);
                    float pushForce = 2.5f;
                    newCube.cubeRigidbody.AddForce(new Vector3(0, 0.3f, 1f) * pushForce, ForceMode.Impulse);
                }


                Collider[] surroundCube = Physics.OverlapSphere(contactPoint, 2f);
                float explosionFoce = 400f;
                float explosionRadius = 1.5f;

                foreach(Collider col in surroundCube)
                {
                    if(col.attachedRigidbody != null)
                    {
                        col.attachedRigidbody.AddExplosionForce(explosionFoce, contactPoint, explosionRadius);


                    }
                }

                ExplosionFX.Instance.PlayerCubeExplosion(contactPoint, cube.cubleColor);

                CubeSpawner.Instance.DestroyCube(cube);
                CubeSpawner.Instance.DestroyCube(otherCube);

            }
        }
    }
}
