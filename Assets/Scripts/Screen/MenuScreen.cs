using Core;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : BaseScreen
{
    [SerializeField] private Button startButton;
  
    private void Start()
    {
        startButton.onClick.AddListener(StartClickButton);
    }

    private void StartClickButton()
    {
        Meta.OnGameScreenAction?.Invoke();
    }
}
