using Core;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BaseScreen
{
    [SerializeField] private Button finishButton;

    private void Start()
    {
        finishButton.onClick.AddListener(FinishClickButton);
    }

    private void FinishClickButton()
    {
        Meta.OnFinishGameRequest();
    }
}