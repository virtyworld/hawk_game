using Core;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : BaseScreen
{
    [SerializeField] private Button goToMainMenuButton;

    private void Start()
    {
        goToMainMenuButton.onClick.AddListener(GoToMainMenuButton);
    }

    private void GoToMainMenuButton()
    { 
        Meta.OnMainScreenAction?.Invoke();
    }
}