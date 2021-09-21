using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamBullet : Ammo
{
    protected LineRenderer lineRenderer;

    protected Transform firePoint;
   
    protected void ShootStream()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        if (hitInfo)
        {
            // Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            // if (enemy != null)
            // {
            //     enemy.TakeDamage(damage);
            // }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);
        }
    }
}