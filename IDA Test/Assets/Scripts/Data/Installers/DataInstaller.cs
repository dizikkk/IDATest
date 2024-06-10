using Zenject;

namespace IDATest
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameData();
        }

        private void BindGameData() => Container.Bind<GameData>().FromNew().AsSingle().NonLazy();
    }
}