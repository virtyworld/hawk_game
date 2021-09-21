
using UnityEngine;

public class CapsuleBullet : Bullet
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
