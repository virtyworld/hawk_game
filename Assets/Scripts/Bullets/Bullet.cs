using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    private float bulletLifeTime;
    private BulletDirection bulletDirection;
    private float speed;
    private BulletLauncher bulletLauncher;
    
    public void Setup(BulletLauncher bulletLauncher)
    {
        this.bulletLauncher = bulletLauncher;
    }
    
    
    private void FixedUpdate()
    {
        BulletMove();
        StartCoroutine(Destroy());
    }

    private void BulletMove()
    {
        if (bulletLauncher.Directions == BulletDirection.up)
        {
            rigidbody.velocity = transform.up * speed;
        }
        else
        {
            rigidbody.velocity = -transform.up * speed;
        }
        
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