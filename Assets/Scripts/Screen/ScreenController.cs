using System;
using UnityEngine;

namespace Screen
{
    public  class ScreenController:BaseScreen
    {
        [SerializeField] private BaseScreen[] screenPrefabs;
        [SerializeField] private GameObject menuDirectory;
       
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
            foreach (Transform child in menuDirectory.transform) {
                GameObject.Destroy(child.gameObject);
            }
            
            Type type = typeof(T);
            BaseScreen bs;
            
            if (type == typeof(GameScreen))
            {
                bs = Instantiate(screenPrefabs[1],menuDirectory.transform);
            }
            else if (type == typeof(FinalScreen))
            {
                bs = Instantiate(screenPrefabs[2],menuDirectory.transform);
            }
            else
            {
                bs = Instantiate(screenPrefabs[0],menuDirectory.transform);
            }

            return  (T) bs;
        }
    }
}