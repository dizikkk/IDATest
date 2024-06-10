using Zenject;

namespace IDATest
{
    public class GameFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindGameFactory();

        private void BindGameFactory() => Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }
}