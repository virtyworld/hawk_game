using Core;
using Screen;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenScript : ScreenController
{
    [SerializeField] private Button startButton;
   

    protected override void Start()
    {
        base.Start();
        
        if (startButton)
        {
            startButton.onClick.AddListener(StartScreen);
        }
    }

    protected override void StartScreen()
    {
        Meta.Instance.GameStartAction.Invoke();
    }
}
