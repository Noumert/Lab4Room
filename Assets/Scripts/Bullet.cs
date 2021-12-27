using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Debug.Log("CHEEEEEEL STENAAAAAAAAAAA");
            PhotonNetwork.Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Debug.Log("CHEEEEEEL POPAAAAAAAAAAAL");
            PlayerMovement playermovement = other.GetComponent<PlayerMovement>();
            playermovement.currentHealth -= 2;
            if (playermovement.currentHealth <= 0)
            {
                PhotonNetwork.Destroy(other.gameObject);
            }
        }


    }
}