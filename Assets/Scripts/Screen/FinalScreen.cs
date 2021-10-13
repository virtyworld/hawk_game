using Core;
using Screen;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : ScreenController
{
    [SerializeField] private Button restartButton;

    protected override void Start()
    {
        base.Start();
        
        if (restartButton)
        {
            restartButton.onClick.AddListener(StartScreen);
        }
    }

    protected override void StartScreen()
    {
        Meta.Instance.GameStartAction.Invoke();
    }
}