using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BaseScreen
{
    [SerializeField] private Button finishButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private Action finishButtonAction;
    
    public void Setup(Action action)
    {
        finishButtonAction = action;
    }
    private void Start()
    {
        finishButton.onClick.AddListener(FinishClickButton);
    }

    private void FixedUpdate()
    {
        scoreText.text = Score.Instance.CurrentScore.ToString();
    }

    private void FinishClickButton()
    {
        finishButtonAction?.Invoke();
    }
}