using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomHolder : MonoBehaviour
{
    [SerializeField] private Text text;

    public RoomInfo info;


    public void SetRoomInfo(RoomInfo info)
    {
        this.info = info;
        text.text = $"max : {info.MaxPlayers} , {info.Name}";
    }
}
