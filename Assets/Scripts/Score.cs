using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score instance;
    
    [SerializeField] private float pointForKillEnemy;
    [SerializeField] private float pointForDamageEnemy;
    [SerializeField] private float pointForDamagePlayer;
    [SerializeField] private float bonus;
   
    private float currentScore;
    private bool isBonus;
    private HashSet<int> enemiesHitPlayer = new HashSet<int>();
    private string saveFile;
    private GameData gameData = new GameData();

    public bool IsBonus => isBonus;
    public static Score Instance => instance;
    public float CurrentScore => currentScore;
    public float BestScore => currentScore > gameData.bestScore ? currentScore : gameData.bestScore;

    private void Awake()
    {
        if (instance == null) { 
            instance = this; 
        } else if(instance == this){ 
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
        ReadFile();
    }

    public void KillEnemy(int instanceId)
    {
        if (!IsEnemyHitPlayer(instanceId))
        {
            StartCoroutine(Bonus());
        }
        currentScore += isBonus ? pointForKillEnemy*bonus : pointForKillEnemy;
    }
   
    public void EnemyHasDamage()
    {
        currentScore += isBonus ? pointForDamageEnemy*bonus : pointForDamageEnemy;
    }

    public void PlayerHasDamage(int instanceId)
    {
        currentScore -= pointForDamagePlayer;
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

    public void SaveScore()
    {
        if (currentScore > gameData.bestScore)
        {
            WriteFile();
        }
    }
    
    private  void ReadFile()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }

    private void WriteFile()
    {
        GameData gd = new GameData();
        gd.bestScore = currentScore;
        string jsonString = JsonUtility.ToJson(gd);
        File.WriteAllText(saveFile, jsonString);
    }
}