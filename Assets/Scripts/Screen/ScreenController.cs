using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Screen
{
    public abstract class ScreenController:MonoBehaviour
    {
        [SerializeField] private Button quitButton;

        protected virtual void Start()
        {
            quitButton.onClick.AddListener(QuitScreen);
        }

        protected abstract void StartScreen();

        protected virtual void QuitScreen()
        {
            Meta.Instance.QuitGameAction.Invoke();
        }
    }
}
