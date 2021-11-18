using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
   
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
            rigidbody.velocity = transform.up * bulletLauncher.Speed;
        }
        if (bulletLauncher.Directions == BulletDirection.down)
        {
            rigidbody.velocity = -transform.up * bulletLauncher.Speed;
        }
    }
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(bulletLauncher.BulletLifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}