using UnityEngine;

namespace Screen
{
    public enum ScreenName { MenuScreen, FinalScreen, GameScreen }
    public  class ScreenController:BaseScreen
    {
        public static ShowScreenDelegate ShowGameScreen;
        
        [SerializeField] private GameObject[] screenPrefabs;
        [SerializeField] private GameObject menuDirectory;
        public delegate BaseScreen ShowScreenDelegate(ScreenName screenName);

        public  ShowScreenDelegate ShowScreen;
        private bool isGameScreen;
       
        private void Start()
        {
            ShowScreen += GetScreen;
            ShowGameScreen += GetScreen;
        }

        private BaseScreen GetScreen<T> (T screen)
        {
            BaseScreen bs;
            
            foreach (Transform child in menuDirectory.transform) {
                GameObject.Destroy(child.gameObject);
            }
            
            if (screen.Equals(ScreenName.FinalScreen))
            {
                GameObject gm = Instantiate(screenPrefabs[2],menuDirectory.transform);
                bs = gm.GetComponent<FinalScreen>();
            }
            else if (screen.Equals(ScreenName.GameScreen))
            {
                GameObject gm = Instantiate(screenPrefabs[1], menuDirectory.transform);
                bs = gm.GetComponent<GameScreen>();
            }
            else
            {
                GameObject gm =  Instantiate(screenPrefabs[0],menuDirectory.transform);
                bs = gm.GetComponent<MenuScreen>();
            }

            return bs;
        }
    }
}