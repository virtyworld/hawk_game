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
        [SerializeField] private Bullet[] bulletPrefabs;
        [SerializeField] private GameObject gameDirectory;
        [SerializeField] private GameObject gameLevelPrefab;
        [SerializeField] private ScreenController screenController;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] protected BulletLauncher bullet1LauncherPrefab ;
        [SerializeField] protected BulletLauncher bullet2LauncherPrefab ;
        
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
                playerScript.Setup(bulletPrefabs);
                gameLevel = Instantiate(gameLevelPrefab, gameDirectory.transform);
                gameScreen = screenController.ShowGameScreen();
                gameScreen.Setup(OnFinishScreenAction);
                enemy1 = enemyController.SpawnEnemy1();
                enemy1.Setup(bullet1LauncherPrefab);
                enemy2 = enemyController.SpawnEnemy2();
                enemy2.Setup(bullet2LauncherPrefab);
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
                // if (enemy1) Destroy(enemy1Script.gameObject);
                // if (enemy2) Destroy(enemy2Script.gameObject);
            }
        }

        private void MainMenu()
        {
            menuScreen = screenController.ShowMainScreen();
            menuScreen.Setup(OnGameScreenAction);
        }
    }
}