using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;

    [SerializeField] private RoomHolder roomHolder;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            RoomHolder holder = Instantiate(roomHolder, content);
            if(holder != null)
            {
                holder.SetRoomInfo(info);
            }
        }
    }
}
