using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float pointForKillEnemy;
    [SerializeField] private float pointForDamageEnemy;
    [SerializeField] private float pointForDamagePlayer;
    [SerializeField] private float bonus;
   
    private float score;
    private bool isBonus;
    private List<int> enemiesHitPlayer = new List<int>();

    
    public float GetScore => score;

    public void KillEnemy(int instanceId)
    {
        if (!IsEnemyHitPlayer(instanceId))
        {
            StartCoroutine(Bonus());
        }
        
        score += isBonus ? pointForKillEnemy*bonus : pointForKillEnemy;
    }
   
    public void EnemyHasDamage()
    {
        score += isBonus ? pointForDamageEnemy*bonus : pointForKillEnemy;
    }

    public void PlayerHasDamage(int instanceId)
    {
        score -= pointForDamagePlayer;
        enemiesHitPlayer.Add(instanceId);
    }

    private IEnumerator Bonus()
    {
        isBonus = true;
        yield return new WaitForSeconds(5);
        isBonus = false;
    }

    private bool IsEnemyHitPlayer(int instanceId)
    {
        return enemiesHitPlayer.Contains(instanceId);
    }
}