using Core;
using Screen;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : ScreenController
{
    [SerializeField] private Button finishButton;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private GameObject mainCamera;
    protected override void Start()
    {
        base.Start();
        
        if (finishButton)
        {
            finishButton.onClick.AddListener(StartScreen);
        }
        // gameCamera.SetActive(true);
        // Camera.main.enabled = false;
        
    }

    protected override void StartScreen()
    {
        Meta.Instance.GameFinishAction.Invoke();
    }
}