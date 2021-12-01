using System;
using System.Collections.Generic;
using Screen;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        private static Action OnGameLevel1ScreenAction;
        private static Action OnGameLevel2ScreenAction;
        private static Action OnFinishScreenAction;
        private static Action OnMainScreenAction;
        
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private GameObject gameDirectory;
        [SerializeField] private GameObject gameLevel1Prefab;
        [SerializeField] private GameObject gameLevel2Prefab;
        [SerializeField] private ScreenController screenController;
        [SerializeField] private Enemy enemy1Prefab;
        [SerializeField] private Enemy enemy2Prefab;

        private Character playerScript;
        private GameObject gameLevel;
        private bool isStartGame;
        private MenuScreen menuScreen;
        private GameScreen gameScreen;
        private FinalScreen finalScreen;
        private Enemy enemy1;
        private Enemy enemy2;
        private List<Enemy> enemyListLevel1 = new List<Enemy>();
        private List<Enemy> enemyListLevel2 = new List<Enemy>();

        private void Start()
        {
            OnGameLevel1ScreenAction += StartGameLevel1;
            OnGameLevel2ScreenAction += StartGameLevel2;
            OnFinishScreenAction += FinishGame;
            OnMainScreenAction += MainMenu;
            MainMenu();
        }

        private void StartGameLevel1()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                gameLevel = Instantiate(gameLevel1Prefab, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnFinishScreenAction);
                EnemyDestroy();
                enemyListLevel1.Add(Instantiate(enemy1Prefab, gameDirectory.transform));
                enemyListLevel1.Add(Instantiate(enemy2Prefab, gameDirectory.transform));
            }
        }
        private void StartGameLevel2()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                gameLevel = Instantiate(gameLevel2Prefab, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnFinishScreenAction);
                EnemyDestroy();
                enemyListLevel2.Add(Instantiate(enemy1Prefab, gameDirectory.transform));
                enemyListLevel2.Add(Instantiate(enemy2Prefab, gameDirectory.transform));
            }
        }
        
        private void FinishGame()
        {
            if (isStartGame)
            {
                isStartGame = false;
                finalScreen = screenController.ShowFinalScreen();
                finalScreen.Setup(OnMainScreenAction);
                EnemyDestroy();
                if (playerScript) Destroy(playerScript.gameObject);
                if (gameLevel) Destroy(gameLevel.gameObject);
            }
        }

        private void MainMenu()
        {
            menuScreen = screenController.ShowMainScreen();
            menuScreen.Setup(OnGameLevel1ScreenAction,OnGameLevel2ScreenAction);
        }
        
        private void EnemyDestroy()
        {
            if (enemyListLevel1.Count > 0)
            {
                foreach (Enemy enemylvl1 in enemyListLevel1)
                {
                    Destroy(enemylvl1.gameObject);
                }
                enemyListLevel1.Clear(); 
            }
            if (enemyListLevel2.Count > 0)
            {
                foreach (Enemy enemylvl2 in enemyListLevel2)
                {
                    Destroy(enemylvl2.gameObject);
                }
                enemyListLevel2.Clear(); 
            }
        }
    }
}