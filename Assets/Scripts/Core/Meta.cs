using System;
using Screen;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        private static Action OnGameLevel1ScreenAction;
        private static Action OnGameLevel2ScreenAction;
        private static Action OnQuitScreenAction;
        private static Action OnLoseScreenAction;
        private static Action OnWinScreenAction;
        private static Action OnMainScreenAction;
        
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private GameObject gameDirectory;
        [SerializeField] private GameObject backgroundLvl1;
        [SerializeField] private GameObject backgroundLvl2;
        [SerializeField] private ScreenController screenController;
        [SerializeField] private ActiveGameZone activeGameZone;
        [SerializeField] private Score scorePrefab;
        [SerializeField] private Chunk[] lvl1Chunks;
        [SerializeField] private Chunk[] lvl2Chunks;

        private Character playerScript;
        private GameObject gameLevel;
        private bool isStartGame;
        private MenuScreen menuScreen;
        private GameScreen gameScreen;
        private FinalScreen finalScreen;
        private Chunk chunk;
        private Score score;

        private void Start()
        {
            OnGameLevel1ScreenAction += StartGameLevel1;
            OnGameLevel2ScreenAction += StartGameLevel2;
            OnQuitScreenAction += QuitGame;
            OnLoseScreenAction += LoseGame;
            OnWinScreenAction += WinGame;
            OnMainScreenAction += MainMenu;
            MainMenu();
        }

        private void StartGameLevel1()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                score = Instantiate(scorePrefab,gameDirectory.transform);
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                playerScript.Setup(score,OnLoseScreenAction);
                gameLevel = Instantiate(backgroundLvl1, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnQuitScreenAction);
                activeGameZone.Setup(lvl1Chunks,OnWinScreenAction,score);
                activeGameZone.SpawnChunk();
               
            }
        }
        private void StartGameLevel2()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                playerScript.Setup(score,OnLoseScreenAction);
                gameLevel = Instantiate(backgroundLvl2, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnQuitScreenAction);
                activeGameZone.Setup(lvl2Chunks,OnWinScreenAction,score);
                activeGameZone.SpawnChunk();
            }
        }
        
        private void QuitGame()
        {
            if (isStartGame)
            {
                isStartGame = false;
                finalScreen = screenController.ShowFinalScreen();
                finalScreen.Setup(OnMainScreenAction);
                finalScreen.QuitGame();
                DeleteAllChild();
                // if (playerScript) Destroy(playerScript.gameObject);
                // if (gameLevel) Destroy(gameLevel.gameObject);
            }
        }
        
        private void LoseGame()
        {
            if (isStartGame)
            {
                isStartGame = false;
                finalScreen = screenController.ShowFinalScreen();
                finalScreen.Setup(OnMainScreenAction);
                finalScreen.LoseGame();
                score.SaveScore();
                DeleteAllChild();
                // if (playerScript) Destroy(playerScript.gameObject);
                // if (gameLevel) Destroy(gameLevel.gameObject);
            }
        }
        
        private void WinGame()
        {
            if (isStartGame)
            {
                isStartGame = false;
                finalScreen = screenController.ShowFinalScreen();
                finalScreen.Setup(OnMainScreenAction);
                finalScreen.WinGame();
                score.SaveScore();
                DeleteAllChild();
                // if (playerScript) Destroy(playerScript.gameObject);
                // if (gameLevel) Destroy(gameLevel.gameObject);
            }
        }

        private void MainMenu()
        {
            menuScreen = screenController.ShowMainScreen();
            menuScreen.Setup(OnGameLevel1ScreenAction,OnGameLevel2ScreenAction);
        }

        private void DeleteAllChild()
        {
            foreach (Transform child in gameDirectory.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}