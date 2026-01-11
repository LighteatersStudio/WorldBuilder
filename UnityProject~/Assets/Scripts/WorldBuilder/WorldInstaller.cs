using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.WorldNode;
using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder
{
    public class WorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<AddressablesInstaller>();
            
            Container.BindFactory<string, WorldNode.WorldNode, Transform, WorldNode.WorldNode, WorldNodeFactory>()
                .FromSubContainerResolve()
                .ByInstaller<WorldNodeInstaller>()
                .AsSingle();

            Container.Bind<WorldNodeBuilder>()
                .AsTransient();
        }
    }
}