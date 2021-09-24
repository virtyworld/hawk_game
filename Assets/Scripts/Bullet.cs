using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        speed = PlayerScript.Instance.BulletSpeed;
    }

    private void FixedUpdate()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        rb.velocity = transform.up * speed;
    }
}