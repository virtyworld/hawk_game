using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float fireRate = 1;

    protected Bullet[] bullet;
    protected float currentTime;
    protected bool isShoot;

}