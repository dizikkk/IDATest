using Zenject;

namespace IDATest
{
    public class GameFactory : IGameFactory
    {
        private IUIFactory uiFactory;

        [Inject]
        public GameFactory(IUIFactory uiFactory)
        {
            this.uiFactory = uiFactory;
        }
        
        public void CreateUI()
        {
            uiFactory.CreateCanvas();
        }
    }
}