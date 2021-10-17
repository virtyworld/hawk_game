using System;
using Screen;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        private static Meta instance;
        
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private GameObject gameLevelPrefab;
        [SerializeField] private Bullet[] bulletPrefabs;
        [SerializeField] private GameObject menuDirectory;
        [SerializeField] private GameObject gameDirectory;
        [SerializeField] private ScreenController startMenuScreenPrefab;
        [SerializeField] private ScreenController gameScreenPrefab;
        [SerializeField] private ScreenController finalMenuScreenPrefab;

        private Character playerScript;
        private GameObject gameLevel;
        private ScreenController startMenuScreen;
        private ScreenController gameMenuScreen;
        private ScreenController finalMenuScreen;
        private bool isStartGame;
        public Action GameStartAction;
        public Action GameFinishAction;
        public Action QuitGameAction;

        public static Meta Instance => instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            } else {
                instance = this;
            }
        }

        private void Start()
        {
            GameStartAction += StartGame;
            GameFinishAction += FinishGame;
            QuitGameAction += QuitGame;
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.I))
            {
                StartMenu();
            }

            if (Input.GetKey(KeyCode.O))
            {
                QuitGame();
            }
        }

        private void StartGame()
        {
            if (!isStartGame)
            {
                if (finalMenuScreen) Destroy(finalMenuScreen.gameObject);
                if (startMenuScreen) Destroy(startMenuScreen.gameObject);
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                playerScript.Setup(bulletPrefabs);
                gameLevel = Instantiate(gameLevelPrefab,gameDirectory.transform);
                gameMenuScreen = Instantiate(gameScreenPrefab, menuDirectory.transform);
                isStartGame = true;
            }
        }
        
        private void FinishGame()
        {
            if (isStartGame)
            {
                if (playerScript) Destroy(playerScript.gameObject);
                if (gameLevel) Destroy(gameLevel.gameObject);
                if (gameMenuScreen) Destroy(gameMenuScreen.gameObject);
                finalMenuScreen = Instantiate(finalMenuScreenPrefab,menuDirectory.transform);
                isStartGame = false;
            }
        }

        private void StartMenu()
        {
            if (!startMenuScreen)
            {
                isStartGame = false;
                startMenuScreen = Instantiate(startMenuScreenPrefab, menuDirectory.transform);
            }
        }

        private void QuitGame()
        {
            isStartGame = false;
            if (gameMenuScreen) Destroy(gameMenuScreen.gameObject);
            if (playerScript) Destroy(playerScript.gameObject);
            if (gameLevel) Destroy(gameLevel.gameObject);
            if (startMenuScreen) Destroy(startMenuScreen.gameObject);
            if (finalMenuScreen) Destroy(finalMenuScreen.gameObject);
        }
    }
}
