using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;

    [SerializeField] private RoomHolder roomHolder;
    private List<RoomHolder> listing = new List<RoomHolder>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listing.FindIndex(x => x.info.Name == info.Name);
                if(index != -1)
                {
                    Destroy(listing[index].gameObject);
                    listing.RemoveAt(index);
                }
            }
            else
            {
                RoomHolder holder = Instantiate(roomHolder, content);
                if (holder != null)
                {
                    holder.SetRoomInfo(info);
                    listing.Add(holder);
                }
            }
        }
    }
}
