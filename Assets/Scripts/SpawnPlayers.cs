using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, maxX, maxY;
    
    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(52,60),Random.Range(-70,-59));
        PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }

}
