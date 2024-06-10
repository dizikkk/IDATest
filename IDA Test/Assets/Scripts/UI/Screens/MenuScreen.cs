using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace IDATest
{
    public class MenuScreen : Screen
    {
        [SerializeField]
        private Transform scrollViewContent;

        private List<LevelCard> levelCards = new();
        
        private IUIFactory uiFactory;
        private GameData gameData;
        
        [Inject]
        private void Construct(IUIFactory uiFactory, GameData gameData)
        {
            this.uiFactory = uiFactory;
            this.gameData = gameData;
        }
        
        public override void Show(LevelData levelData)
        {
            CreateLevelCards();
        }

        public override void Hide() => gameObject.SetActive(false);

        private void CreateLevelCards()
        {
            if (levelCards.Count >= gameData.levelData.Length)
            {
                for (int i = 0; i < gameData.levelData.Length; i++)
                    levelCards[i].Init(gameData.levelData[i]);
                return;
            }

            for (int i = 0; i < gameData.levelData.Length; i++)
            {
                LevelCard levelCard = uiFactory.CreateLevelCard(gameData.levelData[i]);
                levelCards.Add(levelCard);
                levelCard.transform.SetParent(scrollViewContent);
            }
        }
    }
}