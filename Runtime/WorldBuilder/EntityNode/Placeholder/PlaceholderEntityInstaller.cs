using BusinessLogic.WorldBuilder.Builder;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public class PlaceholderEntityInstaller : EntityInstallerBase
    {
        public PlaceholderEntityInstaller(GameObject prefab, Transform parent, ICustomBuildersInstallerBind buildersInstallerBind)
        : base(prefab, parent, buildersInstallerBind)
        {
        }

        protected override void InstallPrefab(GameObject prefab, Transform parent)
        {
            Container.Bind<PlaceholderNodeController>()
                .FromNewComponentOnNewPrefab(prefab)
                .UnderTransform(parent)
                .AsSingle()
                .NonLazy();
        }
    }
}