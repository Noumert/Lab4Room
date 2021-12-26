using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movemnt;
    Vector2 mousePos;

    void Update()
    {
       
        movemnt.x = Input.GetAxisRaw("Horizontal");
        movemnt.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    // Update is called once per frame
    void FixUpdate()
    {
        rb.MovePosition(rb.position + movemnt * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90f;
        rb.rotation = angle; 
    }
}