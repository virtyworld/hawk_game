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
            restartButton.onClick.AddListener(RestartButton);
        }
    }

    private void RestartButton()
    {
        Meta.Instance.GameStartAction.Invoke();
    }
}