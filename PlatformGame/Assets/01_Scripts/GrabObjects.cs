using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPos;
    [SerializeField] private Transform rayPos;

    public float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPos.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            // grab object
            if(grabbedObject == null && Input.GetKey(KeyCode.G))
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPos.position;
                grabbedObject.transform.SetParent(transform);
                grabbedObject.GetComponent<BoxCollider2D>().isTrigger = true;
            } // release object
            else if (Input.GetKeyDown(KeyCode.R))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.GetComponent<BoxCollider2D>().isTrigger = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPos.position, transform.right * rayDistance, Color.red);
    }
}
