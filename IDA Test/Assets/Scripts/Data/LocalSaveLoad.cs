using UnityEngine;
using Zenject;

namespace IDATest
{
    public class LocalSaveLoad
    {
        private ProjectData projectData;
    
        public ProjectData ProjectData => projectData;

        private ISaveLoadSystem saveLoadSystem;
        
        [Inject]
        public LocalSaveLoad(ISaveLoadSystem saveLoadSystem)
        {
            this.saveLoadSystem = saveLoadSystem;
            Init();
        }

        private void Init()
        {
            if (saveLoadSystem.TryLoad(ref projectData)) Debug.Log("Project Data loaded");
            else InitDefaultData();
        }

        private void InitDefaultData()
        {
            projectData = new ProjectData
            {
                levelCounter = new SerializableDictionary<int, int>()
            };
        }

        public void HandleOnApplicationQuit()
        {
            if (saveLoadSystem.TrySave(ref projectData)) {Debug.Log("Project Data saved!");}
        }
        
        public void HandleApplicationPause(bool isPause)
        {
            if (!isPause) return;
            if (saveLoadSystem.TrySave(ref projectData)) Debug.Log("Project Data saved!");
        }
    }
}