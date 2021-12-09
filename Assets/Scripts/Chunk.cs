using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
   [SerializeField] private List<Enemy> enemies;

   private Action OnNextChunkAction;
   public void Setup(Action OnNextChunkAction)
   {
      this.OnNextChunkAction = OnNextChunkAction;
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
}
