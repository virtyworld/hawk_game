using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [Header("Character setup")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private BulletLauncher[] bulletLauncher;
   
    private float currentTime;
    private bool isShoot;
    
    private Vector3 oldCharacterPos;
    private Vector3 oldCursorPos;
    private int randomBulletLauncher;
    private int randomBulletPrefab;

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

        GetRandBulletPrefab();
        
        Bullet bullets =  Instantiate(bulletLauncher[randomBulletLauncher].BulletPrefabs[randomBulletPrefab], new Vector3(position.x, position.y + 1,position.z), Quaternion.identity);
        bullets.Setup(bulletLauncher[randomBulletLauncher]);
    }

    private void GetRandBulletPrefab()
    {
        Bullet bullet = null;
        randomBulletLauncher = Random.Range(0, bulletLauncher.Length);
        
        for (int i = 0; i < bulletLauncher.Length; i++)
        {
            if (randomBulletLauncher == i)
            {
                randomBulletPrefab = Random.Range(0,bulletLauncher[i].BulletPrefabs.Length);
            }
        }

    }
}