using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movemnt;
    Vector2 mousePos;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;
            mousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        }

        /* movemnt.x = Input.GetAxisRaw("Horizontal");
         movemnt.y = Input.GetAxisRaw("Vertical");

         mousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition);*/
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movemnt * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
