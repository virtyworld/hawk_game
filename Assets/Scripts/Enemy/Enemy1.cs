using UnityEngine;

public class Enemy1 : Enemy
{
    // public void Setup(Bullet[] bullet)
    // {
    //     this.bullet = bullet;
    // }
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
        Transform enemy = Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x, position.y - 1,position.z), Quaternion.identity); 
        
    }
}