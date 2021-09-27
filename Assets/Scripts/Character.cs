using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [Header("Character setup")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireRate;
   
    private float currentTime;
    private bool IsShoot;
    private Bullet[] bullet;
  
    public void Setup(Bullet[] bullet)
    {
        this.bullet = bullet;
    }
    
    private void FixedUpdate()
    {
        Shoot();
        Move();
    }
  
    private Vector3 GetMoveInput()
    {
        Vector3 characterVelocity = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            characterVelocity += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterVelocity += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity += new Vector3(1, 0, 0);
        }

        return characterVelocity;
    }

    private void Move()
    {
        Vector3 p = GetMoveInput();
        gameObject.transform.Translate(p * moveSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        if (currentTime == 0)
        {
            IsShoot = true;
            StartCoroutine(Shooting());
        }

        if (IsShoot && currentTime < fireRate)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= fireRate)
        {
            currentTime = 0;
            IsShoot = false;
        }
    }

    IEnumerator Shooting()
    {
        Vector3 position = gameObject.transform.position;
        Transform go = Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x, position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(go.gameObject);
    }
}