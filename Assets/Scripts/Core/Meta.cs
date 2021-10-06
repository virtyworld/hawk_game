using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private Bullet[] bulletPrefabs;
        [SerializeField] private GameObject menu;
        [SerializeField] private Button playButton;
      
        private Character playerScript;
        private bool isStartGame;

        private void Start()
        {
            playButton.onClick.AddListener(TaskOnClick);
        }

        private void FixedUpdate()
        {
            if (!isStartGame && Input.GetKey(KeyCode.I))
            {
                StartGame();
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
                playerScript = Instantiate(playerScriptPrefab);
                playerScript.Setup(bulletPrefabs);
                isStartGame = true;
                OpenCloseMenu(true);
            }
        }
        
        private void FinishGame()
        {
            if (isStartGame)
            {
                Destroy(playerScript.gameObject);
                isStartGame = false;
                OpenCloseMenu(false);
            }
        }
        
        private void OpenCloseMenu(bool isOpen)
        {
            if (isOpen)
            {
               menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }
        
        private void TaskOnClick()
        {
            StartGame();
        }
    }
}
