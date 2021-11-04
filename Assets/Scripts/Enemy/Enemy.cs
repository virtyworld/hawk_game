using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float fireRate = 1;
    
    //test
    [SerializeField]protected GameObject[] bullet;
    
    //private Bullet[] bullet;
    protected float currentTime;
    protected bool isShoot;

}