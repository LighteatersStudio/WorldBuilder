using Zenject;

namespace BusinessLogic.WorldBuilder.AddressablesManagement
{
    public class AddressablesInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<INodeDownloader>()
                .To<FakeNodeDownloader>()
                .AsSingle();

            Container.Bind<AddressablesLoader>()
                .AsSingle();
        }
    }
}