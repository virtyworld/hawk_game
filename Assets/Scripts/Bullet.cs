using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    protected Rigidbody rb;

    private void Update()
    {
        BulletMove();
    }

    protected void BulletMove()
    {
        rb.velocity = transform.up * speed;
    }
   
}
