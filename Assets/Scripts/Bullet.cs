using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
  
    private void FixedUpdate()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        rb.velocity = transform.up * speed;
    }
}