using BusinessLogic.WorldBuilder.Builder;
using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public abstract class EntityInstallerBase : Installer
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;

        private readonly ICustomBuildersInstallerBind _buildersInstallerBind; 
        
        protected EntityInstallerBase(GameObject prefab, Transform parent,  ICustomBuildersInstallerBind buildersInstallerBind)
        {
            _prefab = prefab;
            _parent = parent;
            
            _buildersInstallerBind = buildersInstallerBind;
        }

        public override void InstallBindings()
        {
            _buildersInstallerBind.Bind(Container);

            InstallPrefab(_prefab, _parent);
        }

        protected abstract void InstallPrefab(GameObject prefab, Transform parent);
    }
}