using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    
    [Header("Character setup")]
    [SerializeField] private GameObject character;
    [SerializeField] public float moveSpeed;
    
    [Header("Bullet setup")]
    [SerializeField] private GameObject bulletRed;
    [SerializeField] private GameObject bulletBlue;

    public float MoveSpeed => moveSpeed;

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

    private void Start()
    {
        Instantiate(character);
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        GetInput();
       
    }

   
    
    private void GetInput()
    {
       
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bulletRed);
        }
        

    }
    
   
}
