using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float currentTime;
    private bool isShoot;
    private BulletLauncher bulletLauncher;
    
    public void Setup(BulletLauncher bs)
    {
        this.bulletLauncher = bs;
    }
    
    private void FixedUpdate()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (currentTime == 0)
        {
            isShoot = true;
                
            InstantiateBullet();
        }
    
        if (isShoot && currentTime < bulletLauncher.FireRate)
        {
            currentTime += 1 * Time.deltaTime;
        }
    
        if (currentTime >= bulletLauncher.FireRate)
        {
            currentTime = 0;
            isShoot = false;
        }
    }
    
    private void InstantiateBullet()
    {
        for (int i = 0; i < bulletLauncher.BulletCount; i++)
        {
            Vector3 position = gameObject.transform.position;
            Bullet bullet =  Instantiate(bulletLauncher.BulletPrefabs[Random.Range(0, bulletLauncher.BulletPrefabs.Length)], new Vector3(position.x, position.y - 1,position.z), Quaternion.identity);
            bullet.gameObject.transform.Rotate(new Vector3(0f,0f,-Angle(i)));
            bullet.Setup(bulletLauncher);
        }
    }

    private float Angle(int i)
    {
       float angle = 180 / bulletLauncher.BulletCount+1;
       return i * angle;
    }
}