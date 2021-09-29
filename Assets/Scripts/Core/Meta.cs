using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private Bullet[] bulletPrefabs;

        private Character playerScript;
        private bool isStartGame;
        
        private void FixedUpdate()
        {
            if (!isStartGame && Input.GetKey(KeyCode.I))
            {
                StartGame();
                isStartGame = true;
            }

            if (isStartGame && Input.GetKey(KeyCode.O))
            {
                FinishGame();
                isStartGame = false;
            }
        }

        private void StartGame()
        {
            playerScript = Instantiate(playerScriptPrefab);
            playerScript.Setup(bulletPrefabs);
        }
        
        private void FinishGame()
        {
            Destroy(playerScript.gameObject); 
        }
    }
}
