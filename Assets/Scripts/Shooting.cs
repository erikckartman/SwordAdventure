using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    private int arrows = 10;
    [SerializeField] private Slider bar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && arrows > 0)
        {
            Shoot();
            arrows -= 1;
            bar.value -= 1;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = firePoint.right * bulletSpeed;

        Destroy(bullet, 2f);
    }
}
