using Zenject;

namespace IDATest
{
    public class LevelDataLoadServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindLevelDataLoadService();

        private void BindLevelDataLoadService() => 
            Container.Bind<IlevelDataLoadService>().To<LevelDataLoadService>().FromNew().AsSingle();
    }
}