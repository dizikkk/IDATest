using UnityEngine;
using Zenject;

namespace IDATest
{
    public class JsonDownloadServiceInstaller : MonoInstaller
    {
        [SerializeField]
        private JsonDownloadServiceConfig config;

        public override void InstallBindings()
        {
            BindJsonDownloadService();
            BindJsonDownloadServiceConfig();
        }

        private void BindJsonDownloadServiceConfig() => 
            Container.Bind<JsonDownloadServiceConfig>().FromInstance(config).AsSingle();

        private void BindJsonDownloadService() => 
            Container.Bind<IJsonDownloadService>().To<JsonDownloadService>().FromNew().AsSingle();
    }
}