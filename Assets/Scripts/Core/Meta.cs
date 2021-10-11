using System;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        private static Meta instance;
        
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private Bullet[] bulletPrefabs;
        [Header("Menu settings")]
        [SerializeField] private GameObject menuDirectory;
        [SerializeField] private ScreenController startMenuScreenPrefab;
        [SerializeField] private ScreenController gameScreenPrefab;
        [SerializeField] private ScreenController finalMenuScreenPrefab;

        private Character playerScript;
        private ScreenController startMenuScreen;
        private ScreenController gameMenuScreen;
        private ScreenController finalMenuScreen;
        private bool isStartGame;
        public Action GameStartAction;
        public Action GameFinishAction;

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
        }

        private void FixedUpdate()
        {
            if (!isStartGame && Input.GetKey(KeyCode.I))
            {
                OpenMainMenu();
            }

            if (isStartGame && Input.GetKey(KeyCode.O))
            {
                FinishGame();
            }
        }

        private void StartGame()
        {
            if (!isStartGame)
            {
                if (finalMenuScreen)
                {
                    Destroy(finalMenuScreen.gameObject); 
                }

                if (startMenuScreen)
                {
                    Destroy(startMenuScreen.gameObject);
                }
                playerScript = Instantiate(playerScriptPrefab);
                playerScript.Setup(bulletPrefabs);
                isStartGame = true;
                gameMenuScreen = Instantiate(gameScreenPrefab, menuDirectory.transform);
            }
        }
        
        private void FinishGame()
        {
            if (isStartGame)
            {
                Destroy(playerScript.gameObject);
                isStartGame = false;
                Destroy(gameMenuScreen.gameObject);
                finalMenuScreen = Instantiate(finalMenuScreenPrefab,menuDirectory.transform);
            }
        }

        private void OpenMainMenu()
        {
            if (!startMenuScreen)
            {
                startMenuScreen = Instantiate(startMenuScreenPrefab, menuDirectory.transform);
            }
        }
        

    }
}
