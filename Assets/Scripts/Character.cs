using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [Header("Character setup")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private BulletLauncher bulletLauncher;
    [SerializeField] private float bulletCount;
    [SerializeField] private Health health;
   
    private float currentTime;
    private bool isShoot;
    private Vector3 oldCharacterPos;
    private Vector3 oldCursorPos;
    private Action OnLoseScreenAction;
    private Score score;

    public void Setup(Action OnLoseScreenAction,Score score = null)
    {
        this.OnLoseScreenAction = OnLoseScreenAction;
        this.score = score;
    }

    private void Start()
    {
        health.Setup(OnLoseScreenAction,score);
    }

    private void FixedUpdate()
    {
        Shoot();
        Move();
    }
  
    private void Move()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        cursor.z = 0f;
        
        if (Input.GetMouseButton(0))
        {
            if (oldCursorPos != cursor)
            {
                transform.position = Vector3.Lerp(transform.position,  transform.position + (cursor - oldCursorPos)*4, Time.deltaTime * moveSpeed);
                oldCharacterPos = transform.position + (cursor - oldCursorPos) * 4;
                oldCursorPos = cursor; 
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position,  oldCharacterPos, Time.deltaTime * moveSpeed);
        }

        oldCursorPos = cursor;
    }
  
    private void Shoot()
    {
        if (currentTime == 0)
        {
            isShoot = true;
            bulletLauncher.Shoot(bulletPrefabs[Random.Range(0,bulletPrefabs.Length)],bulletCount);
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
}