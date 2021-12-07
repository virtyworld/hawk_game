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
        [SerializeField] private GameObject backgroundLvl1;
        [SerializeField] private GameObject backgroundLvl2;
        [SerializeField] private ScreenController screenController;
        [SerializeField] private ActiveGameZone activeGameZone;
        [SerializeField] private Chunk[] lvl1Chunks;
        [SerializeField] private Chunk[] lvl2Chunks;

        private Character playerScript;
        private GameObject gameLevel;
        private bool isStartGame;
        private MenuScreen menuScreen;
        private GameScreen gameScreen;
        private FinalScreen finalScreen;
        private Chunk chunk;

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
                gameLevel = Instantiate(backgroundLvl1, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnFinishScreenAction);
                activeGameZone.Setup(lvl1Chunks,playerScript);
                activeGameZone.SpawnChunk();
            }
        }
        private void StartGameLevel2()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                gameLevel = Instantiate(backgroundLvl2, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnFinishScreenAction);
                activeGameZone.Setup(lvl2Chunks,playerScript);
                activeGameZone.SpawnChunk();
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
            menuScreen.Setup(OnGameLevel1ScreenAction,OnGameLevel2ScreenAction);
        }

        
    }
}