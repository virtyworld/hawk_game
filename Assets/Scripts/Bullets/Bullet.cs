using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammo
{
    [SerializeField] protected float speed = 20f;

    protected Rigidbody2D rb;


    protected void BulletMove()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //effect
            //Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}