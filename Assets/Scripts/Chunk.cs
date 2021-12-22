using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemiesPrefab;
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private BoxCollider collider;

    private Action OnNextChunkAction;
    private int screenSizeWidth;
    private int screenSizeHeight;
    private List<Enemy> enemies = new List<Enemy>();
    private float orthographicSize;
    private float aspect;
   
   
    public void Setup(Action OnNextChunkAction)
    {
        this.OnNextChunkAction = OnNextChunkAction;
    }

    private void Start()
    {
        SpawnEnemies();
        BoundsInit();
    }

    private void FixedUpdate()
    {
        if (IsEnemiesDie())
        {
            OnNextChunkAction?.Invoke();
            Destroy(gameObject);
        }
    }

    private bool IsEnemiesDie()
    {
        enemies.RemoveAll(x => x == null);
      
        if (enemies.Count == 0)
        {
            return true;
        }

        return false;
    }

    private void SpawnEnemies()
    {
        float verticalSize   = Camera.main.orthographicSize * 2.0f;
        float horizontalSize = verticalSize * UnityEngine.Screen.width / UnityEngine.Screen.height;
      
        for (int i = 0; i < enemiesPrefab.Count; i++)
        {
            Enemy enemy = Instantiate(enemiesPrefab[i],spawnPositions[i].parent);
            float posX = Random.Range(-(transform.position.x  + horizontalSize / 2), transform.position.x + horizontalSize / 2);
            float posY = Random.Range(transform.position.y - 1 + verticalSize / 2, transform.position.y + verticalSize / 2) - 0.5f;
          
            if (spawnPositions[i].position.x > transform.position.x+horizontalSize/2 || spawnPositions[i].position.y > transform.position.y+verticalSize/2)
            {
                enemy.gameObject.transform.position = new Vector3( posX, posY, 0);
            }
            else
            {
                enemy.gameObject.transform.position = new Vector3( spawnPositions[i].position.x,spawnPositions[i].position.y, 0);
            }
            enemies.Add(enemy);
        }
    }


    private void BoundsInit()
    {
        float verticalSize   = Camera.main.orthographicSize * 2.0f;
        float horizontalSize = verticalSize * UnityEngine.Screen.width / UnityEngine.Screen.height;
        float scale = (float)UnityEngine.Screen.width / UnityEngine.Screen.height;
        collider.size = new Vector3(horizontalSize/scale,verticalSize/scale,15);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}