using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.Builder;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public class EntityBuilder<TEntity, TPrefabLoader, TContext> : EntityBuilderBase<TEntity, TPrefabLoader>
        where TPrefabLoader : IPrefabLoader
    {
        private readonly EntityFactory<TEntity, TContext> _factory;
        public EntityBuilder(TPrefabLoader prefabLoader, IAssetPathBuilder pathBuilderBuilder, EntityFactory<TEntity, TContext> factory) 
            : base(prefabLoader, pathBuilderBuilder)
        {
            _factory = factory;
        }
        
        public UniTask<TEntity> Build(string subGroupName, string assetName, Transform parent, TContext context)
        {
            return LoadPrefab(PathBuilderBuilder.GetAssetPath(subGroupName, assetName), parent,
                (prefab, transform) => _factory.Create(prefab, transform, context));
        }
    }
}