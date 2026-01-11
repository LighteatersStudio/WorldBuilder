using BusinessLogic.WorldBuilder.Builder;
using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder.WorldNode
{
    public class WorldNodeInstaller : Installer<WorldNodeInstaller>
    {
        private readonly BundleName _bundleName;
        private readonly WorldNode _prefab;
        private readonly Transform _parent;

        private readonly ICustomBuildersInstallerBind _buildersInstallerBind; 

        [Inject]
        public WorldNodeInstaller(string bundleName, WorldNode prefab, Transform parent, ICustomBuildersInstallerBind buildersInstallerBind)
        {
            _bundleName = new BundleName(bundleName);
            
            _prefab = prefab;
            _parent = parent;

            _buildersInstallerBind = buildersInstallerBind;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<BundleName>()
                .FromInstance(_bundleName)
                .AsSingle();
            
            _buildersInstallerBind.Bind(Container);
            
            Container.Bind<WorldNode>()
                .FromComponentInNewPrefab(_prefab)
                .UnderTransform(_parent)
                .AsSingle()
                .NonLazy();
            
            // Container.Bind<IPlaceable>()
            //     .To<MonoPlaceable>()
            //     .FromResolveGetter<WorldNode>(node => node.GetComponent<MonoPlaceable>())
            //     .AsSingle()
            //     .NonLazy();
        }
    }
}