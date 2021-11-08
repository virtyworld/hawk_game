using UnityEngine;

public class Enemy2 : Enemy
{
    [SerializeField] private float bulletAngle;

    public void Setup(EnemyBullet[] bullet)
    {
        this.bullet = bullet;
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
        if (bulletAngle != 0)
        {
            Transform bullet1 = Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x + 0.5f, position.y - 0.5f,position.z), Quaternion.identity);
            bullet1.Rotate(new Vector3(0f,0f,bulletAngle));
            Transform bullet2  = Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x - 0.5f, position.y - 0.5f ,position.z), Quaternion.identity);
            bullet2.Rotate(new Vector3(0f,0f,-bulletAngle));
        }
        else
        {
            Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x, position.y - 1,position.z), Quaternion.identity); 
        }
    }
}