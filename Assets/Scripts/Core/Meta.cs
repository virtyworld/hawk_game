using Screen;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        public static OnStartGameRequestDelegate OnStartGameRequest;
        public static OnFinishGameRequestDelegate OnFinishGameRequest;
        
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private Bullet[] bulletPrefabs;
        [SerializeField] private GameObject gameDirectory;
        [SerializeField] private GameObject gameLevelPrefab;
        [SerializeField] private ScreenController screenController;
        

        private Character playerScript;
        private GameObject gameLevel;
        private bool isStartGame;
        private BaseScreen mainScreen, gameScreen, finalScreen;

        public delegate void OnStartGameRequestDelegate();
        public delegate void OnFinishGameRequestDelegate();

        private void Start()
        {
            OnStartGameRequest += StartGame;
            OnFinishGameRequest += FinishGame;
            mainScreen = screenController.ShowScreen(ScreenName.MenuScreen);
        }


        private void StartGame()
        {
            if (!isStartGame)
            {
                isStartGame = true;
                playerScript = Instantiate(playerScriptPrefab,gameDirectory.transform);
                playerScript.Setup(bulletPrefabs);
                gameLevel = Instantiate(gameLevelPrefab, gameDirectory.transform);
                if (mainScreen) Destroy(mainScreen.gameObject);
                gameScreen = screenController.ShowScreen(ScreenName.GameScreen);
            }
        }
        
        private void FinishGame()
        {
            if (isStartGame)
            {
                isStartGame = false;
                finalScreen = screenController.ShowScreen(ScreenName.FinalScreen);
                if (playerScript) Destroy(playerScript.gameObject);
                if (gameLevel) Destroy(gameLevel.gameObject);
            }
        }
    }
}