using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    
    [Header("Character setup")]
    [SerializeField] private GameObject character;
    [SerializeField] private Movement movement;
    [SerializeField] public float moveSpeed;
    private bool IsGameStart;
    private GameObject gameCharacter;
    private Vector3 p_Velocity ;
    
    [Header("Bullet setup")]
    [SerializeField] private GameObject[] bulletsPrefab;
    [SerializeField] private float fireRate;
    private float currentTime;
    private bool shoot;

    public float MoveSpeed => moveSpeed;
    public GameObject Character => character;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Shoot();
        move();
    }
   
    
    private void GetInput()
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
        Vector3 p_Velocity = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }

        return p_Velocity;
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

    private void move()
    {
        if (IsGameStart && gameCharacter)
        {
            GetMoveInput();
            gameCharacter.transform.Translate(p_Velocity * moveSpeed * Time.deltaTime);
        }
        
    }

    private void Shoot()
    {
        if (IsGameStart && gameCharacter)
        {
            if (currentTime == 0)
            {
                shoot = true;
                StartCoroutine(Shooting());
            }

            if (shoot && currentTime < fireRate)
            {
                currentTime += 1 * Time.deltaTime;
            }

            if (currentTime >= fireRate)
            {
                currentTime = 0;
                shoot = false;
            }
            
        }

    }
   
   
    IEnumerator Shooting()
    {
       Transform go =  Instantiate(bulletsPrefab[Random.Range(0,bulletsPrefab.Length)].transform, new Vector3(gameCharacter.transform.position.x,gameCharacter.transform.position.y + 1),
            Quaternion.identity);

       yield return new WaitForSeconds(fireRate);
        Destroy(go.gameObject);
        yield break;
    }
}
