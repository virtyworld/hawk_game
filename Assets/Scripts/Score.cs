using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float pointForKillEnemy;
    [SerializeField] private float pointForDamageEnemy;
    [SerializeField] private float pointForDamagePlayer;
    [SerializeField] private float bonus;
   
    private float currentScore;
    private bool isBonus;
    private List<int> enemiesHitPlayer = new List<int>();
    private string saveFile;
    private GameData gameData = new GameData();
    
    public float GetCurrentScore => currentScore;
    public float BestScore => currentScore > gameData.BestScore ? currentScore : gameData.BestScore;
    
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
        Debug.Log("KillEnemy "+isBonus + " "+currentScore+" "+currentScore + " "+pointForKillEnemy*bonus);
        currentScore += isBonus ? pointForKillEnemy*bonus : pointForKillEnemy;
       
    }
   
    public void EnemyHasDamage()
    {
        currentScore += isBonus ? pointForDamageEnemy*bonus : pointForDamageEnemy;
        Debug.Log("EnemyHasDamage "+isBonus + " "+pointForDamageEnemy+" "+bonus);
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
        if (currentScore > gameData.BestScore)
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
        gd.Setup(currentScore);
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFile, jsonString);
    }
}