using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Text Healthbar;
    public float maxHealth = 10;
    public float currentHealth;
    public Text textName;
    
    Vector2 movemnt;
    Vector2 mousePos;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
        currentHealth = maxHealth;
        Healthbar.text = maxHealth + "/" + currentHealth;
        textName.text = view.Owner.NickName;
    }
    void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * moveSpeed * Time.deltaTime;
            transform.position += (Vector3) moveAmount;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            changeRotation();

        }
        Healthbar.text = maxHealth + "/" + currentHealth;
    }
    void changeRotation()
    {
        rb.MovePosition(rb.position + movemnt * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

}
