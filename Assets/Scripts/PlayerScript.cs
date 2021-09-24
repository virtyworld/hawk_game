using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    private static PlayerScript instance;

    [Header("Character setup")]
    [SerializeField] private GameObject character;
    [SerializeField] private float moveSpeed;
   
    [Header("Bullet setup")] 
    [SerializeField] private GameObject[] bulletsPrefab;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    
    private bool IsGameStart;
    private GameObject gameCharacter;
    private float currentTime;
    private bool IsShoot;

    public static PlayerScript Instance => instance;
    public float BulletSpeed => bulletSpeed;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void FixedUpdate()
    {
        StartStopGame();
        Shoot();
        Move();
    }

    private void StartStopGame()
    {
        if (Input.GetKey(KeyCode.I))
        {
            StartGame();
        }

        if (Input.GetKey(KeyCode.O))
        {
            StopGame();
        }
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

    private void StartGame()
    {
        if (!IsGameStart)
        {
            gameCharacter = Instantiate(character);
            IsGameStart = true;
        }
    }

    private void StopGame()
    {
        if (IsGameStart && gameCharacter)
        {
            Destroy(gameCharacter);
            IsGameStart = false;
        }
    }

    private void Move()
    {
        if (IsGameStart && gameCharacter)
        {
            Vector3 p = GetMoveInput();
            gameCharacter.transform.Translate(p * moveSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (IsGameStart && gameCharacter)
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
    }

    IEnumerator Shooting()
    {
        Vector3 position = gameCharacter.transform.position;
        Transform go = Instantiate(bulletsPrefab[Random.Range(0, bulletsPrefab.Length)].transform, new Vector3(position.x, position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(go.gameObject);
        yield break;
    }
}