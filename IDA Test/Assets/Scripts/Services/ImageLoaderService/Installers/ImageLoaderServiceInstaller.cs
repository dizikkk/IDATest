using Zenject;

namespace IDATest
{
    public class ImageLoaderServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindImageLoaderService();
        }

        private void BindImageLoaderService() => 
            Container.Bind<IImageLoaderService>().To<ImageLoaderService>().FromNew().AsSingle().NonLazy();
    }
}