using BusinessLogic.WorldBuilder.Builder;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public class EntityInstaller<TEntity, TContext> : EntityInstaller<TEntity>
    {
        private readonly TContext _context;

        public EntityInstaller(GameObject prefab, Transform parent, ICustomBuildersInstallerBind buildersInstallerBind, TContext context)
            : base(prefab, parent, buildersInstallerBind)
        {
            _context = context;
        }

        protected override void InstallPrefab(GameObject prefab, Transform parent)
        {
            Container.Bind<TContext>()
                .FromInstance(_context)
                .AsSingle();
            
            base.InstallPrefab(prefab, parent);
        }
    }
}