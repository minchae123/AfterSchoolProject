using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public string roomName = "�� ���̾�";
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

        Debug.Log("���� �ұ� ���� ��");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("��");
        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameManager.instance.SpawnPlayer();
        GameManager.instance.SpawnVirus();

        foreach(Player p in PhotonNetwork.PlayerList)
        {
            Debug.Log(p.NickName);   
        }

        Debug.Log("��� ���� !");
    }
}
