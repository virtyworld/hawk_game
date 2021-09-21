using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : Bullet
{
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        BulletMove();
    }
}
