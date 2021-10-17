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
            startButton.onClick.AddListener(StartButton);
        }
    }

    private  void StartButton()
    {
        Meta.Instance.GameStartAction.Invoke();
    }
}
