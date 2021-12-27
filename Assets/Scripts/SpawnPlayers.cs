using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, maxX, maxY;
    public Text WinText;
    public float timeLeft = 10f;
    public static bool isGameStart = false;
    public Vector2[] vectorArray = new Vector2[4] { new Vector2(-135, 64), new Vector2(145, 73), new Vector2(141, -58), new Vector2(-148, -65) };

    void Start()
    {
        var room = PhotonNetwork.CurrentRoom.PlayerCount;

        PhotonNetwork.Instantiate(player.name, vectorArray[room - 1], Quaternion.identity);


    }
    private void Update()
    {
        var countPlayer = PhotonNetwork.CurrentRoom.PlayerCount;
        if (countPlayer>=2 && isGameStart == false)
        {
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 )
            {
                isGameStart = true;
                PhotonNetwork.CurrentRoom.IsOpen = false;
            }
        }
        Collider2D[] collidersArray = Physics2D
            .OverlapCircleAll(transform.position, 99999);
        if (isGameStart==true)
        {
            int playerCount = 0;
            Collider2D winPlayer = new Collider2D();
            for (int i = 0; i < collidersArray.Length; i++)
            {
                if (collidersArray[i].tag == "Player")
                {
                    playerCount++;
                    winPlayer = collidersArray[i];
                }
                
            }

            if (playerCount == 1)
            {
                PlayerMovement playerMovement = winPlayer.GetComponent<PlayerMovement>();
                WinText.text = "Переміг гравець " + playerMovement.textName.text;
                PhotonNetwork.CurrentRoom.IsOpen = true; 
                isGameStart = false;
            }
        }
    }



}
