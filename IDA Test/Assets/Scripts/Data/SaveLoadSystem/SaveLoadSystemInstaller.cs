using UnityEngine;
using Zenject;

namespace IDATest
{
    public class SaveLoadSystemInstaller : MonoInstaller
    {
        [SerializeField]
        private SaveLoadSystemConfig config;
        
        public override void InstallBindings()
        {
            BindSaveLoadSystemConfig();
            BindSaveLoadSystem();
            BindLocalSaveLoad();
        }

        private void BindSaveLoadSystemConfig() => Container.Bind<SaveLoadSystemConfig>().FromInstance(config).AsSingle().NonLazy();
        private void BindSaveLoadSystem() => Container.Bind<ISaveLoadSystem>().To<SaveLoadSystem>().AsSingle().NonLazy();
        private void BindLocalSaveLoad() => Container.Bind<LocalSaveLoad>().FromNew().AsSingle().NonLazy();
    }
}