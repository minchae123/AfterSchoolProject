using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour, IPunObservable
{
    public Camera cam;
    public float speed;

    public Text nick;
    public PhotonView pv;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //throw new System.NotImpementedException();
    }

    private void Awake()
    {
        Debug.Log(pv.Owner.NickName);
        nick.text = pv.IsMine ? PhotonNetwork.NickName : pv.Owner.NickName;
        nick.transform.parent.GetComponent<Canvas>().worldCamera = cam;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (pv.IsMine)
        {
            Vector2 input = Input.mousePosition;
            Vector3 worldPos = cam.ScreenToWorldPoint(input);
            Vector3 nPos = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);

            nPos.z = transform.position.z;
            transform.position = nPos;
        }
    }
}
