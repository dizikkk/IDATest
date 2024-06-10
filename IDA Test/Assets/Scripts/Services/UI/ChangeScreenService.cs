using Zenject;

namespace IDATest
{
    public class ChangeScreenService : IChangeScreenService
    {
        private OverlayCanvas canvas;
        
        [Inject]
        public ChangeScreenService(OverlayCanvas canvas) => this.canvas = canvas;

        public void ShowMenuScreen() => canvas.ShowScreen<MenuScreen>();

        public void ShowLevelScreen(LevelData levelData) => canvas.ShowScreen<LevelScreen>(levelData);
    }
}