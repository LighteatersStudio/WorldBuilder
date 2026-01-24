using BusinessLogic.WorldBuilder.Builder;
using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public class EntityInstaller<TEntity> : EntityInstallerBase
    {
        public EntityInstaller(GameObject prefab, Transform parent, ICustomBuildersInstallerBind buildersInstallerBind)
            : base(prefab, parent, buildersInstallerBind)
        {
        }

        protected override void InstallPrefab(GameObject prefab, Transform parent)
        {
            if (prefab.TryGetComponent(out GameObjectContext _))
            {
                Debug.Log(
                    $"A GameObjectContext was detected. A {typeof(TEntity)} instance will be taken from the context, not directly from the prefab.  The instance must be bind to the context.");
                
                Container.Bind<TEntity>()
                    .FromSubContainerResolve()
                    .ByNewContextPrefab(prefab)
                    .UnderTransform(parent)
                    .AsSingle()
                    .NonLazy();
            }
            else
            {
                Container.Bind<TEntity>()
                    .FromComponentInNewPrefab(prefab)
                    .UnderTransform(parent)
                    .AsSingle()
                    .NonLazy();    
            }
            
        }
    }
}