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
            bullet.gameObject.transform.Rotate(new Vector3(0f,0f,GetAngle(directions,bulletCount,i)));
        }
    }

    private float GetAngle(BulletDirection direction,float bulletCount,float i)
    {
        if (direction == BulletDirection.up)
        {
            if (bulletCount == 1)
            {
                return 180;
            }

            if (bulletCount % 2 == 0)
            {
               
                if (angle * bulletCount <= 180)
                {
                    if (bulletCount / 2 >= i)
                    {
                        return (angle * i)+180;
                    }
                    else
                    {
                        return -angle * (i - (bulletCount / 2))+180;
                    }
                }
                else
                {
                    return (180 / bulletCount * i)+90;
                }   
            }
            else
            {
                if (angle * bulletCount <= 180)
                {
                    return angle * i+90;
                }
                else
                {
                    return (180 / bulletCount * i)+90;
                } 
            }
        }
        if (direction == BulletDirection.down)
        {
            if (bulletCount == 1)
            {
                return 0;
            }

            if (bulletCount % 2 == 0)
            {
               
                if (angle * bulletCount <= 180)
                {
                    if (bulletCount / 2 >= i)
                    {
                        return (angle * i);
                    }
                    else
                    {
                        return -angle * (i - (bulletCount / 2));
                    }
                }
                else
                {
                    return (180 / bulletCount * i)+90;
                }   
            }
            else
            {
                if (angle * bulletCount <= 180)
                {
                    return angle * i+90;
                }
                else
                {
                    return (180 / bulletCount * i)+90;
                } 
            }
        }
        return 0;
    }
}