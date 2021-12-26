using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Leave : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Q key was released.");
            LeaveRoom();
        }
    }
    
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Menu");
    }
}
