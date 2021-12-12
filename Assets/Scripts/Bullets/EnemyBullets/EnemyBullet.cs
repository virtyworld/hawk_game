using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float bulletLifeTime;

    private void FixedUpdate()
    {
        BulletMove();
        StartCoroutine(DestroyBullet());
    }

    private void BulletMove()
    {
        rigidbody.velocity = -transform.up * speed;
    }
    
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
