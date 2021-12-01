using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : BaseScreen
{
    [SerializeField] private Button startLevel1Button;
    [SerializeField] private Button startLevel2Button;
    
    private Action startLevel1ButtonAction;
    private Action startLevel2ButtonAction;

    public void Setup(Action level1Action,Action level2Action)
    {
        this.startLevel1ButtonAction = level1Action;
        this.startLevel2ButtonAction = level2Action;
    }
    private void Start()
    {
        startLevel1Button.onClick.AddListener(StartLevel1ClickButton);
        startLevel2Button.onClick.AddListener(StartLevel2ClickButton);
    }

    private void StartLevel1ClickButton()
    {
        startLevel1ButtonAction?.Invoke();
    }
    private void StartLevel2ClickButton()
    {
        startLevel2ButtonAction?.Invoke();
    }
}
