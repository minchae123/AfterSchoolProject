using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public string roomName = "내 방이얌";
    public InputField nickInput;
 
    private void Start()
    {
        Debug.Log("Connecting");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.LocalPlayer.NickName = nickInput.text;
        nickInput.gameObject.SetActive(false);

        Debug.Log("연결 할까 말까 ㅋ");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("고");
        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameManager.instance.SpawnPlayer();
        Debug.Log("어딜 들어와 !");
    }
}
