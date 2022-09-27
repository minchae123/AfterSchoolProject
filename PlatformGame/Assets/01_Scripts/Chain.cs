using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public LineRenderer line;
    public Camera mainCam;
    public DistanceJoint2D distanceJoint;

    private void Start()
    {
        distanceJoint.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(0, mousePos);
            line.SetPosition(1, transform.position);
            line.enabled = true;
            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = mousePos;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            line.enabled = false;
            distanceJoint.enabled = false;
        }

        if (distanceJoint.enabled)
        {
            line.SetPosition(1, transform.position);
        }
    }
}
