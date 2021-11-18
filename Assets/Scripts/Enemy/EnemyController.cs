using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy enemy1Prefab;
    [SerializeField] private Enemy enemy2Prefab;
    [SerializeField] private GameObject gameDirectory;
    [SerializeField] private BulletLauncher[] bulletLaunchers;
    
    private List<float> currentTimes = new List<float>();
    private List<bool> isShoots = new List<bool>();
    private List<Enemy> enemies = new List<Enemy>();

    private void FixedUpdate()
    {
        Shoot();
    }
    
    public Enemy SpawnEnemy1()
    {
        return GetEnemy(enemy1Prefab,bulletLaunchers[0]);
    } 
    public Enemy SpawnEnemy2()
    {
        return GetEnemy(enemy2Prefab,bulletLaunchers[1]);
    }

    private Enemy GetEnemy(Enemy enemy,BulletLauncher bl)
    {
        Enemy e = enemies.FirstOrDefault(x => x == enemy);
      
        if (e == null)
        {
            e = Instantiate(enemy,gameDirectory.transform);
            //e.Setup(bl);
            currentTimes.Add(0f);
            isShoots.Add(false);
            enemies.Add(e);
        }
        return e;
    }

    private void Shoot()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (currentTimes[i] == 0)
            {
                isShoots[i] = true;
                
                InstantiateBullet(i,enemies[i].transform);
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
    
    private void InstantiateBullet(int number,Transform transform)
    {
        for (int i = 0; i < bulletLaunchers[number].BulletCount; i++)
        {
            Bullet bullet =  Instantiate(bulletLaunchers[number].BulletPrefabs[Random.Range(0, bulletLaunchers[number].BulletPrefabs.Length)], new Vector3(transform.position.x, transform.position.y,transform.position.z), Quaternion.identity);
            bullet.gameObject.transform.Rotate(new Vector3(0f,0f,Angle(bulletLaunchers[number].BulletCount,i)));
            bullet.Setup(bulletLaunchers[number]);
            
           Debug.Log(Angle(bulletLaunchers[number].BulletCount,i));
        }
    }

    private float Angle(float bulletCount,int i)
    {
        float angle = -90;

        if (bulletCount == 1)
        {
            angle += 90;
        }

        if (bulletCount > 1)
        {
            angle = -90 / bulletCount;
            angle = i * angle - (angle/2);
        }
        return angle;
    }

}