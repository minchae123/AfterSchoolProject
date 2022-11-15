using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static PhotonRoom room;
    public int currentScene;
    public int multiplayScene;
    public Text txtInfo;
    int numConnected;

    private void Awake()
    {
        if(PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            if (PhotonRoom.room != this) 
            {
                Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartGame()
    {
        string msMatchFound = "Match found, string a game (VS)";
        txtInfo.text = msMatchFound;
        Debug.Log(msMatchFound);
        PhotonNetwork.LoadLevel(multiplayScene);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log(message: "We are in a room");
        numConnected = PhotonNetwork.PlayerList.Length;
        string msJoinRoom = "Connext Room Name : " + PhotonNetwork.CurrentRoom.Name + "Players connected : " + numConnected;
        Debug.Log(msJoinRoom);
        txtInfo.text = string.Format(msJoinRoom, PhotonNetwork.CurrentRoom.Name, numConnected);
        Debug.Log(message: string.Format(msJoinRoom, PhotonNetwork.CurrentRoom.Name, numConnected));

        StartGame();
    }
}
