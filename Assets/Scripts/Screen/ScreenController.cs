using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Screen
{
    public  class ScreenController:BaseScreen
    {
        [SerializeField] private BaseScreen[] screenPrefabs;
        [SerializeField] private GameObject menuDirectory;

        private List<BaseScreen> screens = new List<BaseScreen>();

        public GameScreen ShowGameScreen()
        {
            return GetScreen<GameScreen>();
        }
        public MenuScreen ShowMainScreen()
        {
            return GetScreen<MenuScreen>();
        }
        public FinalScreen ShowFinalScreen()
        {
            return GetScreen<FinalScreen>();
        }

        private T GetScreen<T> () where T:BaseScreen
        {
            Type type = typeof(T);
            HideScreen();
            BaseScreen screen = GetScreen(type);

            return  (T) screen;
        }
        
        private void HideScreen()
        {
            if (screens.Count > 0)
            {
                foreach (BaseScreen screen in screens)
                {
                    screen.gameObject.SetActive(false);
                }
            }
        }

        private BaseScreen GetScreen(Type type)
        {
            BaseScreen screen = screens.FirstOrDefault(x => x.GetType() == type);
            
            if (screen == null)
            {
                screen = screenPrefabs.FirstOrDefault(x => x.GetType() == type);
                screen =  Instantiate(screen,menuDirectory.transform);
                screens.Add(screen);
            }
            else
            {
                screen.gameObject.SetActive(true); 
            }

            return screen;
        }
    }
}