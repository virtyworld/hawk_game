using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour
    {
        [SerializeField] private Character playerScriptPrefab;
        [SerializeField] private Bullet[] bulletPrefabs;

        private Character playerScript;
        private bool IsStartGame;
        private void FixedUpdate()
        {
            if (!IsStartGame && Input.GetKey(KeyCode.I))
            {
                StartGame();
                IsStartGame = true;
            }

            if (IsStartGame && Input.GetKey(KeyCode.O))
            {
                FinishGame();
                IsStartGame = false;
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
