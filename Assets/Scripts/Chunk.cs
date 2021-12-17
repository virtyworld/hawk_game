using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
   [SerializeField] private List<Enemy> enemiesPrefab;
   [SerializeField] private List<Transform> spawnPositions;
   [SerializeField] private Transform plane;
   [SerializeField] private Transform rightBound;
   [SerializeField] private Transform leftBound;
   [SerializeField] private Transform topBound;
   [SerializeField] private Transform bottomBound;
   [SerializeField] private BoxCollider collider;

   private Action OnNextChunkAction;
   private int screenSizeWidth;
   private int screenSizeHeight;
   private Score score;
   private List<Enemy> enemies = new List<Enemy>();
   private float orthographicSize;
   private float aspect;
   
   
   public void Setup(Score score,Action OnNextChunkAction)
   {
      this.OnNextChunkAction = OnNextChunkAction;
      this.score = score;
   }

   private void Start()
   {
      SpawnEnemies();
      PlaneSize();
      BoundsInit();
      // float aspect = (float)UnityEngine.Screen.width / UnityEngine.Screen.height;
      // Debug.Log("aspect "+aspect);
      // float orthographicSize = Camera.main.orthographicSize * 2.0f;
      // float width = orthographicSize * aspect/10;
      // float height = orthographicSize * aspect/10;
      // //transform.localScale = new Vector3(width, height, 1);
      // Debug.Log("new Vector3(width, height, 1) "+new Vector3(width, height, 1));
      // float widthScale = Scailing.Instance.GetScale;
      // float heightScale = Scailing.Instance.GetScale;
      // Debug.Log(" transform.localScale "+ new Vector3(widthScale,heightScale,1));
   }

   private void FixedUpdate()
   {
      if (IsEnemiesDie())
      {
         OnNextChunkAction?.Invoke();
         Destroy(this);
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
   
   //TODO: create spawn enemies in chunk and set position * scale

   private void SpawnEnemies()
   {
      float verticalSize   = Camera.main.orthographicSize * 2.0f;
      float horizontalSize = verticalSize * UnityEngine.Screen.width / UnityEngine.Screen.height;
      
       for (int i = 0; i < enemiesPrefab.Count; i++)
      {
         Enemy enemy = Instantiate(enemiesPrefab[i],spawnPositions[i].parent);
         
         if (spawnPositions[i].position.x > transform.position.x+horizontalSize/2 || spawnPositions[i].position.y > transform.position.y+verticalSize/2)
         {
            enemy.gameObject.transform.position = new Vector3(  Random.Range(transform.position.x, transform.position.x + horizontalSize / 2),Random.Range(transform.position.y, transform.position.y + verticalSize / 2), 0);
         }
         else
         {
            enemy.gameObject.transform.position = new Vector3( spawnPositions[i].position.x,spawnPositions[i].position.y, 0);
         }
         enemy.Setup(score);
         enemies.Add(enemy);
      }
   }

   private void PlaneSize()
   {
      // plane.localScale = new Vector3();
   }

   private void BoundsInit()
   {
      float verticalSize   = Camera.main.orthographicSize * 2.0f;
      float horizontalSize = verticalSize * UnityEngine.Screen.width / UnityEngine.Screen.height;
      collider.size = new Vector3(horizontalSize,verticalSize,15);
      //
      // rightBound.position = new Vector3((transform.position.x+(horizontalSize/2)),transform.position.y,0);
      // rightBound.localScale = new Vector3(0.1f,verticalSize,15);
      // leftBound.localScale = new Vector3(0.1f,verticalSize,15);
      // leftBound.position = new Vector3(-(transform.position.x+(horizontalSize/2)),transform.position.y,0);
      // topBound.localScale = new Vector3(horizontalSize,0.1f,15);
      // topBound.position = new Vector3(transform.position.x,transform.position.y+verticalSize/2,0);
      // bottomBound.localScale = new Vector3(horizontalSize,0.1f,15);
      // bottomBound.position = new Vector3(transform.position.x,(transform.position.y-verticalSize/2),0);
    
   }
}
