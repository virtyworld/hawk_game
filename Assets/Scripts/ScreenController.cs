using Core;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    [Header("StartMenuScreen")]
    [SerializeField] private Button startMenuScreenButton;
    [Header("GameScreen")]
    [SerializeField] private Button gameScreenButton;
    [Header("FinalMenuScreen")]
    [SerializeField] private Button finalMenuScreenButton;

    void Start()
    {
        if (startMenuScreenButton)
        {
            startMenuScreenButton.onClick.AddListener(StartMenuScreen);
        }
        if (gameScreenButton)
        {
            gameScreenButton.onClick.AddListener(GameScreen);
        }
        if (finalMenuScreenButton)
        {
            finalMenuScreenButton.onClick.AddListener(FinishMenuScreen);
        }
    }
   
    private void StartMenuScreen()
    {
        Debug.Log("StartMenuScreen ");
        Meta.Instance.GameStartAction.Invoke();
        //Destroy(gameObject);
    }

    private void GameScreen()
    {
        Debug.Log("GameScreen ");
        Meta.Instance.GameFinishAction.Invoke();
        //Destroy(gameObject);
    }
    
    private void FinishMenuScreen()
    {
        Debug.Log("FinishMenuScreen ");
        Meta.Instance.GameStartAction.Invoke();
        //Destroy(gameObject);
    }
}
