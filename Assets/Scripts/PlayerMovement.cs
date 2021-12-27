using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Text Healthbar;
    public float maxHealth = 10;
    public float currentHealth;

    Vector2 movemnt;
    Vector2 mousePos;

    PhotonView view;

    void Start()
    {
        
        view = GetComponent<PhotonView>();
        currentHealth = maxHealth;
        Healthbar.text = maxHealth + "/" + currentHealth;
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
        ///Debug.Log(currentHealth);
        if (currentHealth<=0)
        {
            PhotonNetwork.Destroy(gameObject);
        }

    }
    void changeRotation()
    {
        rb.MovePosition(rb.position + movemnt * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        // Vector3 rotationVector = new Vector3(0, angle, 0);
        // Quaternion rotation = Quaternion.Euler(rotationVector);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 720f * Time.deltaTime);
    }
    

}
