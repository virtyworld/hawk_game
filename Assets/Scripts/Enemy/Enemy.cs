using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletCount;
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private BulletLauncher bulletLauncher;
  
    private float currentTimes;
    private bool isShoots;

    private void FixedUpdate()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (currentTimes == 0)
        {
            isShoots = true;
            bulletLauncher.Shoot(bulletPrefabs[Random.Range(0,bulletPrefabs.Length)],bulletCount);
        }
        
        if (isShoots && currentTimes < fireRate)
        {
            currentTimes += 1 * Time.deltaTime;
        }
        
        if (currentTimes >= fireRate)
        {
            currentTimes = 0;
            isShoots = false;
        }
    }
}