using UnityEngine;

namespace IDATest
{
    public abstract class Screen : MonoBehaviour
    {
        public abstract void Show(LevelData levelData = default);
        public abstract void Hide();
    }
}