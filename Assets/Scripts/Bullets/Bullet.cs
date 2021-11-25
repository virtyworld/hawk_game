using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
   
    private float speed;
    private float bulletLifeTime;
    
    public void Setup(float speed,float bulletLifeTime)
    {
        this.speed = speed;
        this.bulletLifeTime = bulletLifeTime;
    }

    private void FixedUpdate()
    {
        BulletMove();
        StartCoroutine(Destroy());
    }

    private void BulletMove()
    {
        rigidbody.velocity = -transform.up * speed;
    }
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}