using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BulletLauncher bulletLauncher;
    [SerializeField] private Health health;
    [SerializeField] private float fireRate;
  
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
            bulletLauncher.Shoot();
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