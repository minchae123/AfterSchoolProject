using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomHolder : MonoBehaviour
{
    [SerializeField] private Text text;


    public void SetRoomInfo(RoomInfo info)
    {
        text.text = $"max : {info.MaxPlayers} , {info.Name}";
    }
}
