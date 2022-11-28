using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float speed;

    public Text nick;
    public PhotonView pv;

    private void Start()
    {
        cam = Camera.main;
        nick.text = pv.IsMine ? PhotonNetwork.NickName : pv.Owner.NickName;
        nick.transform.parent.GetComponent<Canvas>().worldCamera = cam;
    }

    private void Update()
    {
        Vector2 input = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(input);
        Vector3 nPos = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);

        nPos.z = transform.position.z;
        transform.position = nPos;
    }
}
