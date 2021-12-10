using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletCount;
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private BulletLauncher bulletLauncher;
    [SerializeField] private Health health;
  
    private float currentTimes;
    private bool isShoots;
    private Score score;

    public void Setup(Score score)
    {
        this.score = score;
    }

    private void Start()
    {
        health.Setup(score);
    }

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