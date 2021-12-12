using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : BaseScreen
{
    [SerializeField] private Button goToMainMenuButton;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private CanvasGroup canvas;

    private Action goToMainMenuButtonAction;
    private bool isLose;
    private bool isWin;

    public void Setup(Action action)
    {
        goToMainMenuButtonAction = action;
    }
    
    private void Start()
    {
        goToMainMenuButton.onClick.AddListener(GoToMainMenuButton);
        
        if (isLose || isWin)
        {
            canvas.alpha = 0;
        }
    }

    private void Update()
    {
        if (isLose || isWin)
        {
            if (canvas.alpha < 1)
            {
                canvas.alpha += Time.deltaTime / 2;
            }
        }
    }

    private void GoToMainMenuButton()
    { 
        goToMainMenuButtonAction?.Invoke();
    }

    public void QuitGame()
    {
        title.text = "Quit game";
        description.text = "Are you really want to quit the game?";
    }

    public void LoseGame()
    {
        isLose = true;
        title.text = "Game over";
        description.text = "You lose.\n Current score: "+Score.Instance.CurrentScore+"\nBest score: "+Score.Instance.BestScore; 
    }

    public void WinGame()
    {
        isWin = true;
        title.text = "Game over";
        description.text = "You win.\n Current score: "+Score.Instance.CurrentScore+"\nBest score: "+Score.Instance.BestScore; 
    }
}