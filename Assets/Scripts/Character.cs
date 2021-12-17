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

    public void Setup(Score score,Action OnLoseScreenAction)
    {
        this.OnLoseScreenAction = OnLoseScreenAction;
        this.score = score;
    }

    private void Start()
    {
        health.Setup(score,OnLoseScreenAction);
        
        float scale = Scailing.Instance.GetScale;
        transform.localScale = new Vector3(scale,scale,scale);
        Bounds b = new Bounds();
        b.size = new Vector3(10, 10, 10);
        
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
        
        float verticalSize   = Camera.main.orthographicSize * 2.0f;
        float horizontalSize = verticalSize * UnityEngine.Screen.width / UnityEngine.Screen.height;

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
            transform.position = Vector3.Lerp(transform.position, oldCharacterPos, Time.deltaTime * moveSpeed);
        }
        
        oldCursorPos = cursor;
        
        if (transform.position.x < -horizontalSize/2)
        {
            transform.position = new Vector3(-horizontalSize/2, transform.position.y, 0);
        }
        if (transform.position.x > horizontalSize/2)
        {
            transform.position = new Vector3(horizontalSize/2, transform.position.y, 0);
        }
        if (transform.position.y < -verticalSize/2)
        {
            transform.position = new Vector3(transform.position.x, -verticalSize/2, 0);
        }
        if (transform.position.y > verticalSize/2)
        {
            transform.position = new Vector3(transform.position.x, -verticalSize/2, 0);
        }
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

    private void OnCollisionEnter(Collision other)
    {
        // if (transform.position.x < xMovementClamp || transform.position.x > xMovementClamp)
        // {
        //     // transform.position = Vector3.Lerp(transform.position, bounds, Time.deltaTime * moveSpeed);
        //     transform.position = new Vector3(xMovementClamp, transform.position.y, 0);
        //     oldCharacterPos = transform.position;
        //  
        // }
        //
        // if (transform.position.y < yMovementClamp || transform.position.y > yMovementClamp)
        // {
        //     //transform.position = Vector3.Lerp(transform.position, bounds, Time.deltaTime * moveSpeed);
        //     transform.position = new Vector3(transform.position.x, yMovementClamp, 0);
        //     oldCharacterPos = transform.position;
        //     
        // }
    }
}