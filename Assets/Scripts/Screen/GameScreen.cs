using Core;
using Screen;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : ScreenController
{
    [SerializeField] private Button finishButton;

    private GameObject gameCamera;
    protected override void Start()
    {
        base.Start();
        
        if (finishButton)
        {
            finishButton.onClick.AddListener(FinishButton);
        }
    }

    private void FinishButton()
    {
        Meta.Instance.GameFinishAction.Invoke();
    }
}