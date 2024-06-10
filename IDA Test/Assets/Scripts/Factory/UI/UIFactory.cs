using UnityEngine;
using Zenject;

namespace IDATest
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer diContainer;
        private readonly UIFactoryConfig config;
        
        public UIFactory(DiContainer diContainer, UIFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }
        
        public void CreateCanvas()
        {
            OverlayCanvas canvas = diContainer.InstantiatePrefabForComponent<OverlayCanvas>(config.canvasPrefab);
            diContainer.Bind<OverlayCanvas>().FromInstance(canvas).AsSingle().NonLazy();
            LevelScreen levelScreen = diContainer.InstantiatePrefabForComponent<LevelScreen>(config.levelScreenPrefab);
            levelScreen.transform.SetParent(canvas.transform);
            RectTransform rt = levelScreen.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(0f,0f);
            rt.offsetMax = new Vector2(0f,0f);
            levelScreen.gameObject.SetActive(false);
            canvas.Init();
            canvas.AddScreen(levelScreen);
        }

        public LevelCard CreateLevelCard(LevelData levelData)
        {
            LevelCard levelCard = diContainer.InstantiatePrefabForComponent<LevelCard>(config.levelCardPrefab);
            levelCard.Init(levelData);
            return levelCard;
        }
    }
}