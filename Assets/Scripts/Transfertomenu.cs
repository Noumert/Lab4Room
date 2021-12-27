using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfertomenu : MonoBehaviour
{
    public void NextLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
