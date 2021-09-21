using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private StreamBullet[] streamBullets;
    [SerializeField] private float fireRate;

    private Weapon weapon;
    private Transform firePoint;
    private float currentTime;
    private bool shoot;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        firePoint = GameObject.FindWithTag("firePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime == 0 && Input.GetButtonDown("Fire1"))
        {
            shoot = true;
            Shooting();
        }

        if (shoot && currentTime < fireRate)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= fireRate)
        {
            currentTime = 0;
            shoot = false;
        }
    }

    void Shooting()
    {
        if (GetRandomRangeWeapons() > 50)
        {
            //simple bullets
            //need to check array Length
            if (GetRandomRangeBullets() > 50 && bulletPrefabs.Length > 1)
            {
                StartCoroutine(ShootBullet());
            }
            else
            {
                StartCoroutine(ShootBullet());
            }
        }
        else
        {
            //stream bullets
            if (GetRandomRangeBullets() > 50 && streamBullets.Length > 1)
            {
                StartCoroutine(ShootStream());
            }
            else
            {
                StartCoroutine(ShootStream());
            }
        }
    }

    IEnumerator ShootStream()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
       
        StreamBullet sb = Instantiate(weapon.StreamBullet, hitInfo.point, Quaternion.identity);

        yield return new WaitForSeconds(1);

        Destroy(sb.gameObject);
    }

    IEnumerator ShootBullet()
    {
        Bullet bullet = Instantiate(weapon.Bullet, firePoint.position, firePoint.rotation);

        yield return new WaitForSeconds(1);

        Destroy(bullet.gameObject);
    }

    private int GetRandomRangeWeapons()
    {
        return Random.Range(1, 100);
    }

    private int GetRandomRangeBullets()
    {
        return Random.Range(1, 100);
    }
}