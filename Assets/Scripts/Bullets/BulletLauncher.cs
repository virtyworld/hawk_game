using UnityEngine;

public enum BulletDirection {up,down}
public class BulletLauncher : BaseLauncher
{
    [SerializeField] protected float speed;
    [SerializeField] protected float bulletLifeTime;
    [SerializeField] protected float bulletCount;
    [SerializeField] protected Bullet[] bulletPrefabs;
    [SerializeField] protected BulletDirection directions;
    [SerializeField] protected float fireRate;

    public float BulletCount => bulletCount;
    public float Speed => speed;
    public float BulletLifeTime => bulletLifeTime;
    public Bullet[] BulletPrefabs => bulletPrefabs;
    public BulletDirection Directions => directions;
    public float FireRate => fireRate;
}