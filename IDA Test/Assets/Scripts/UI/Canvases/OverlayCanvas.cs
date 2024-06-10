using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IDATest
{
    public class OverlayCanvas : Canvas
    {
        [SerializeField]
        private List<Screen> screens;

        private Screen currentScreen;

        public override void Init()
        {
            ShowScreen<MenuScreen>();
        }

        public void ShowScreen<T>(LevelData levelData = default) where T : Screen
        {
            TryHideCurrentScreen();
            Screen screen = screens.First(x => x is T);
            if (screen == null) return;
            currentScreen = screen;
            screen.gameObject.SetActive(true);
            screen.Show(levelData);
        }

        private void TryHideCurrentScreen()
        {
            if (currentScreen == null) return;
            currentScreen.Hide();
        }

        public void AddScreen(Screen screen)
        {
            screens.Add(screen);
        }
    }
}