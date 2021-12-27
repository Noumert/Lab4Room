using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public InputField inputName;
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public void SaveName()
    {
        PlayerPrefs.SetString("name", inputName.text);
        PhotonNetwork.NickName = inputName.text;
    }

    public void Start()
    {
        
        inputName.text = PlayerPrefs.GetString("name");
        PhotonNetwork.NickName = inputName.text;
    }
    
}
