using System;
using System.Collections.Generic;
using UnityEngine;

namespace Screen
{
    public  class ScreenController:BaseScreen
    {
        [SerializeField] private BaseScreen[] screenPrefabs;
        [SerializeField] private GameObject menuDirectory;

        private List<BaseScreen> baseScreens = new List<BaseScreen>();

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
            BaseScreen bs;
            
            ScreenQueue();
            
            foreach (BaseScreen screen in baseScreens)
            {
                if (type == screen.GetType())
                {
                    screen.gameObject.SetActive(true);
                    return  (T) screen;
                }
            }

            if (type == typeof(GameScreen))
            {
                bs = Instantiate(screenPrefabs[1],menuDirectory.transform);
                baseScreens.Add(bs);
            }
            else if (type == typeof(FinalScreen))
            {
                bs = Instantiate(screenPrefabs[2],menuDirectory.transform);
                baseScreens.Add(bs);
            }
            else
            {
                bs = Instantiate(screenPrefabs[0],menuDirectory.transform);
                baseScreens.Add(bs);
            }

            return  (T) bs;
        }
        
        private void ScreenQueue()
        {
            if (baseScreens.Count > 0)
            {
                foreach (BaseScreen screen in baseScreens)
                {
                    screen.gameObject.SetActive(false);
                }
            }
        }
    }
}