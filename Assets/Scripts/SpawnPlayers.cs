using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, maxX, maxY;
    public Vector2[] vectorArray = new Vector2[4] { new Vector2(-135, 64), new Vector2(145, 73), new Vector2(141, -58), new Vector2(-148, -65) };

    void Start()
    {
        var room = PhotonNetwork.CurrentRoom.PlayerCount;

        PhotonNetwork.Instantiate(player.name, vectorArray[room - 1], Quaternion.identity);


    }
    private void Update()
    {
        var countPlayer = PhotonNetwork.CurrentRoom.PlayerCount;
        if (countPlayer==1)
        {

        }
    }



}
