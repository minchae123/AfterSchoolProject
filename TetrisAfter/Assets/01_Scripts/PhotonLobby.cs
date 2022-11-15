using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    RoomInfo[] rooms;
    public GameObject btnJoin;
    public GameObject btnLeave;
    public Text txtInfo;
    public Text txtNumPlayers;

    private void Awake()
    {
        lobby = this;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        int numPlayers = PhotonNetwork.CountOfPlayers;
        txtNumPlayers.text = "Players : " + numPlayers.ToString() + "/ 20";
    }

    public override void OnConnectedToMaster()
    {
        string message = "Connected to master";
        Debug.Log(message);
        txtInfo.text = message;
        PhotonNetwork.AutomaticallySyncScene = true;
        btnJoin.SetActive(true);
    }

    public void OnJoinButtonClick()
    {
        Debug.Log(message: "Joing button click");
        btnJoin.SetActive(false);
        btnJoin.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string mes = "Failde to join room";
        Debug.Log(mes);
        txtInfo.text = mes;
        CreateRoom();
    }

    private void CreateRoom()
    {
        string me = "Trying to create room";
        Debug.Log(me);
        txtInfo.text = me;
        int randomRoomName = UnityEngine.Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 20 };
        PhotonNetwork.CreateRoom(roomName: "Room" + randomRoomName, roomOps);
    }

    public void OnCancleButtonClick()
    {
        btnLeave.SetActive(false);
        btnJoin.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
