using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BaseScreen
{
    [SerializeField] private Button finishButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Score score;
    private Action finishButtonAction;
    
    public void Setup(Action action,Score score = null)
    {
        finishButtonAction = action;
        this.score = score;
    }
    private void Start()
    {
        finishButton.onClick.AddListener(FinishClickButton);
    }

    private void FixedUpdate()
    {
        scoreText.text = score.GetCurrentScore.ToString();
    }

    private void FinishClickButton()
    {
        finishButtonAction?.Invoke();
    }
}