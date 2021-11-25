using System;
using Screen;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        private static Action OnGameScreenAction;
        private static Action OnFinishScreenAction;
        private static Action OnMainScreenAction;
        
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private GameObject gameDirectory;
        [SerializeField] private GameObject gameLevelPrefab;
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

        private void Start()
        {
            OnGameScreenAction += StartGame;
            OnFinishScreenAction += FinishGame;
            OnMainScreenAction += MainMenu;
            MainMenu();
        }

        private void StartGame()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                gameLevel = Instantiate(gameLevelPrefab, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnFinishScreenAction);
                enemy1 = Instantiate(enemy1Prefab, gameDirectory.transform);
                enemy2 = Instantiate(enemy2Prefab, gameDirectory.transform);
            }
        }
        
        private void FinishGame()
        {
            if (isStartGame)
            {
                isStartGame = false;
                finalScreen = screenController.ShowFinalScreen();
                finalScreen.Setup(OnMainScreenAction);
                if (playerScript) Destroy(playerScript.gameObject);
                if (gameLevel) Destroy(gameLevel.gameObject);
            }
        }

        private void MainMenu()
        {
            menuScreen = screenController.ShowMainScreen();
            menuScreen.Setup(OnGameScreenAction);
        }
    }
}