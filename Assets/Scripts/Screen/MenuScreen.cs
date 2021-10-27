using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : BaseScreen
{
    [SerializeField] private Button startButton;
    
    private Action startButtonAction;

    public void Setup(Action action)
    {
        this.startButtonAction = action;
    }
    private void Start()
    {
        startButton.onClick.AddListener(StartClickButton);
    }

    private void StartClickButton()
    {
        startButtonAction?.Invoke();
    }
}
