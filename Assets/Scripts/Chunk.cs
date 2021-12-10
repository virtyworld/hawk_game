using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
   [SerializeField] private List<Enemy> enemies;
   [SerializeField] private List<Transform> spawnPositions;

   private Action OnNextChunkAction;
   private int screenSizeWidth;
   private int screenSizeHeight;
   private Score score;
   public void Setup(Action OnNextChunkAction,Score score = null)
   {
      this.OnNextChunkAction = OnNextChunkAction;
      this.score = score;
   }

   private void Start()
   {
      SpawnEnemies();
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
      float aspect = (float)UnityEngine.Screen.width / UnityEngine.Screen.height;
      float orthographicSize = Camera.main.orthographicSize * 2.0f;
      float width = orthographicSize * aspect/10;
      float height = orthographicSize * aspect/10;

      for (int i = 0; i < enemies.Count; i++)
      {
         Enemy enemy = Instantiate(enemies[i],spawnPositions[i]);
         enemy.gameObject.transform.position = new Vector3( spawnPositions[i].position.x*width,
            spawnPositions[i].position.y/height, 0);
         enemy.Setup(score);
      }
   }
}
