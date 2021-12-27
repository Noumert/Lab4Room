using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        SceneManager.LoadScene("Menu");
    }
}
