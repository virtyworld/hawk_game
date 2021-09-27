using System.Collections;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletLifeTime;
  
    private void FixedUpdate()
    {
        BulletMove();
        StartCoroutine(Destroy());
    }

    private void BulletMove()
    {
        rb.velocity = transform.up * speed;
    }
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}