using System;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : BaseScreen
{
    [SerializeField] private Button goToMainMenuButton;

    private Action goToMainMenuButtonAction;
    
    public void Setup(Action action)
    {
        goToMainMenuButtonAction = action;
    }
    
    private void Start()
    {
        goToMainMenuButton.onClick.AddListener(GoToMainMenuButton);
    }

    private void GoToMainMenuButton()
    { 
        goToMainMenuButtonAction?.Invoke();
    }
}