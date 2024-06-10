using System.IO;
using UnityEngine;

namespace IDATest
{
    public class LevelDataLoadService :  IlevelDataLoadService
    {
        private GameData gameData;
        private JsonDownloadServiceConfig jsonDownloadServiceConfig;
        
        public LevelDataLoadService(GameData gameData, JsonDownloadServiceConfig jsonDownloadServiceConfig)
        {
            this.gameData = gameData;
            this.jsonDownloadServiceConfig = jsonDownloadServiceConfig;
        }

        public void Load()
        {
            string path = Application.dataPath + $"/{jsonDownloadServiceConfig.jsonName}.json";
            GameData gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(path));
            this.gameData.levelData = gameData.levelData;
        }
    }
}