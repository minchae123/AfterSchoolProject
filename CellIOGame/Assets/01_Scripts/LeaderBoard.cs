using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject txt;
    public ScrollRect leaderBoard;
    List<TPlayer> playerList = new List<TPlayer>();

    private void Start()
    {
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            TPlayer tp = new TPlayer();
            tp.nick = p.NickName;
            playerList.Add(tp);
            Debug.Log(p.NickName);
        }
    }

    public void UpdateLeaderBoard()
    {
        if(playerList.Count > leaderBoard.content.childCount)
        {
            Instantiate(txt, leaderBoard.content);
        }

        IEnumerator e = leaderBoard.content.transform.GetEnumerator();

        playerList.OrderByDescending(i => i.score);
        playerList.ForEach(f =>
        {
            e.MoveNext();
            Transform t = (Transform)e.Current;
            t.gameObject.GetComponent<Text>().text = "" + f.nick + " : " + f.score ;
        }
        );
    }

    public class TPlayer
    {
        public string nick;
        public int score;
    }
}
