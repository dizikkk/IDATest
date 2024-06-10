namespace IDATest
{
    public interface IUIFactory
    {
        public void CreateCanvas();
        public LevelCard CreateLevelCard(LevelData levelData);
    }
}