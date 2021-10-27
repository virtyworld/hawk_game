using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BaseScreen
{
    [SerializeField] private Button finishButton;

    private Action finishButtonAction;
    public void Setup(Action action)
    {
        finishButtonAction = action;
    }
    private void Start()
    {
        finishButton.onClick.AddListener(FinishClickButton);
    }

    private void FinishClickButton()
    {
        finishButtonAction?.Invoke();
    }
}