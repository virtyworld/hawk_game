using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [Header("Character setup")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireRate;
   
    private float currentTime;
    private bool isShoot;
    private Bullet[] bullet;
    private Vector3 target;
  
    public void Setup(Bullet[] bullet)
    {
        this.bullet = bullet;
    }

    private void Start()
    {
        target = transform.position;
    }

    private void FixedUpdate()
    {
        Shoot();
        Move();
    }
  
    private void GetMoveInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            target += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            target += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            target += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            target += new Vector3(1, 0, 0);
        }
    }

    private void Move()
    {
        GetMoveInput();
        transform.position = Vector3.Lerp (transform.position,  target,  Time.deltaTime * moveSpeed);
    }

    private void Shoot()
    {
        if (currentTime == 0)
        {
            isShoot = true;
            Shooting();
        }

        if (isShoot && currentTime < fireRate)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= fireRate)
        {
            currentTime = 0;
            isShoot = false;
        }
    }

    private void Shooting()
    {
        Vector3 position = gameObject.transform.position;
        Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x, position.y + 1), Quaternion.identity);
    }
}