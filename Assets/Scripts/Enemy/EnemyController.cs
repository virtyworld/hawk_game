using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [SerializeField] private Enemy[] enemyPrefabs;
   [SerializeField] private GameObject gameDirectory;

   private List<Enemy> enemies = new List<Enemy>();
   
   public void Setup()
   {
      
   }

   public Enemy1 SpawnEnemy1()
   {
      return GetEnemy<Enemy1>();
   }
   
   public Enemy2 SpawnEnemy2()
   {
      return  GetEnemy<Enemy2>();
   }
   
   private T GetEnemy<T>() where T:Enemy
   {
      Type type = typeof(T);
      Enemy enemy = GetEnemy(type);
      return (T)enemy;
   }
   
   private Enemy GetEnemy(Type type)
   {
      Enemy enemy = enemies.FirstOrDefault(x => x.GetType() == type);
      
      if (enemy == null)
      {
         enemy = enemyPrefabs.FirstOrDefault(x => x.GetType() == type);
         enemy = Instantiate(enemy,gameDirectory.transform);
         enemies.Add(enemy);
      }
      return enemy;
   }
}
