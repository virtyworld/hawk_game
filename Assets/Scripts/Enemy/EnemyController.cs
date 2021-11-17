using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    [SerializeField] private Enemy enemy1Prefab;
    [SerializeField] private Enemy enemy2Prefab;
    [SerializeField] private GameObject gameDirectory;
    [SerializeField] private BulletLauncher[] bulletLaunchers;
    
    private List<float> currentTimes;
    private List<bool> isShoots;
    
    private List<Enemy> enemies = new List<Enemy>();

    public Enemy SpawnEnemy1()
    {
        return GetEnemy(enemy1Prefab);
    } 
    public Enemy SpawnEnemy2()
    {
        return GetEnemy(enemy2Prefab);
    }

    private Enemy GetEnemy(Enemy enemy)
    {
        Enemy e = enemies.FirstOrDefault(x => x == enemy);
      
        if (e == null)
        {
            e = Instantiate(enemy,gameDirectory.transform);
         
            enemies.Add(e);
        }
        return e;
    }
    
    private void FixedUpdate()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (currentTimes[i] == 0)
            {
                isShoots[i] = true;
                
                InstantiateBullet(i);
            }
    
            if (isShoots[i] && currentTimes[i] < bulletLaunchers[i].FireRate)
            {
                currentTimes[i] += 1 * Time.deltaTime;
            }
    
            if (currentTimes[i] >= bulletLaunchers[i].FireRate)
            {
                currentTimes[i] = 0;
                isShoots[i] = false;
            } 
        }
        
    }
    
    private void InstantiateBullet(int number)
    {
        for (int i = 0; i < bulletLaunchers[number].BulletCount; i++)
        {
            Vector3 position = gameObject.transform.position;
            Bullet bullet =  Instantiate(bulletLaunchers[number].BulletPrefabs[Random.Range(0, bulletLaunchers[number].BulletPrefabs.Length)], new Vector3(position.x, position.y - 1,position.z), Quaternion.identity);
            bullet.gameObject.transform.Rotate(new Vector3(0f,0f,-Angle(bulletLaunchers[number].BulletCount)));
            bullet.Setup(bulletLaunchers[number]);
        }
    }

    private float Angle(float bulletCount)
    {
        float angle = 180 / bulletCount+1;
        return bulletCount * angle;
    }
}