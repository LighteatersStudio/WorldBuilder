using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.Builder;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public class EntityBuilder<TEntity, TPrefabLoader> : EntityBuilderBase<TEntity, TPrefabLoader> 
        where TPrefabLoader : IPrefabLoader
    {
        private readonly EntityFactory<TEntity> _factory;
        
        public EntityBuilder(TPrefabLoader prefabLoader, IAssetPathBuilder pathBuilderBuilder, EntityFactory<TEntity> factory) 
            : base(prefabLoader, pathBuilderBuilder)
        {
            _factory = factory;
        }

        public UniTask<TEntity> Build(string assetName, Transform parent)
        {
            return LoadPrefab(PathBuilderBuilder.GetAssetPath(assetName), parent, _factory.Create);
        }
        
        public UniTask<TEntity> Build(string subGroupName, string assetName, Transform parent)
        {
            return LoadPrefab(PathBuilderBuilder.GetAssetPath(subGroupName, assetName), parent, _factory.Create);
        }
    }
}