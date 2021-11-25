using UnityEngine;

public enum BulletDirection {up,down}
public class BulletLauncher : BaseLauncher
{
    [SerializeField] protected float speed;
    [SerializeField] protected float bulletLifeTime;
    [SerializeField] protected BulletDirection directions;
    [SerializeField] protected float angle;

    public void Shoot(Bullet bulletPrefab,float bulletCount)
    {
        for (int i = 1; i < bulletCount+1; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab,new Vector3(transform.position.x, transform.position.y,transform.position.z), Quaternion.identity);
            bullet.Setup(speed,bulletLifeTime);
            bullet.gameObject.transform.Rotate(new Vector3(0f,0f,GetAngle(directions,angle,bulletCount,i)));
        }
    }

    private float GetAngle(BulletDirection direction,float eachAngle,float bulletCount,float i)
    {
        if (direction == BulletDirection.up)
        {
            if (bulletCount == 1)
            {
                return 180;
            }
        
            if (i % 2 == 0)
            {
                return eachAngle+180;
            }
            else
            {
                return -eachAngle+180;
            }
        }
        
        if (direction == BulletDirection.down)
        {
            if (bulletCount == 1)
            {
                return 0;
            }
        
            if (i % 2 == 0)
            {
                return eachAngle;
            }
            else
            {
                return -eachAngle;
            }
        }

        return 0;
    }
}