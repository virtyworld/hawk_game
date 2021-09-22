using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        rb.velocity = transform.up * speed;
    }
   
}
