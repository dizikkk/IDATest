using Zenject;

namespace IDATest
{
    public class ChangeScreenServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindChangeScreenService();
        }

        private void BindChangeScreenService() => 
            Container.Bind<IChangeScreenService>().To<ChangeScreenService>().FromNew().AsSingle();
    }
}