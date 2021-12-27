using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float range = 20f;


    private List<GameObject> bullets;

    PhotonView view;

    void Start()
    {
        // bulletsAmount = bulletsMaxAmount;
        bullets = new List<GameObject>();
        view = GetComponent<PhotonView>();
        // bulletsText.text = bulletsAmount + "/" + bulletsMaxAmount;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (view.IsMine && SpawnPlayers.isGameStart == true)
            {
                Shoot();
            }
            //Shoot();

            /*if (bulletsAmount > 0)
            {
                bulletsAmount -= 1;
                Shoot();
                bulletsText.text = bulletsAmount + "/" + bulletsMaxAmount;
            }*/
        }
        ClearBulletsByRange();


    }
    private void ClearBulletsByRange()
    {
        if (bullets.Count == 0)
        {
            return;
        }

        foreach (int bulletI in Enumerable.Range(0, bullets.Count))
        {
            if (bullets.ElementAt(bulletI).IsDestroyed())
            {
                bullets.RemoveAt(bulletI);
                return;
            }
            float bulletRange = Vector2.Distance(bullets.ElementAt(bulletI)
                .transform.position, firePoint.position);
            if (bulletRange >= range)
            {
                PhotonNetwork.Destroy(bullets.ElementAt(bulletI));
                //Destroy(bullets.ElementAt(bulletI));
                bullets.RemoveAt(bulletI);
                return;
            }
        }
    }

    void Shoot()
    {
        var bullet = PhotonNetwork.Instantiate("Bullet", firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullets.Add(bullet);
    }
}
