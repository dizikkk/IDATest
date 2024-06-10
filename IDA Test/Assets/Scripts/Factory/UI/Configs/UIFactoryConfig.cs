using UnityEngine;

namespace IDATest
{
    [CreateAssetMenu(fileName = "UIFactoryConfig", menuName = "Game/UI/New UIFactoryConfig", order = 0)]
    public class UIFactoryConfig : ScriptableObject
    {
        public Canvas canvasPrefab;
        public LevelScreen levelScreenPrefab;
        public LevelCard levelCardPrefab;
    }
}