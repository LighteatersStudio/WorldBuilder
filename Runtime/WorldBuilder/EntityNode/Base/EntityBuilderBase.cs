using System;
using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.Builder;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public abstract class EntityBuilderBase<TEntity, TPrefabLoader> : PrefabBuilder where TPrefabLoader : IPrefabLoader
    {
        protected readonly IAssetPathBuilder PathBuilderBuilder;

        protected EntityBuilderBase(TPrefabLoader prefabLoader, IAssetPathBuilder pathBuilderBuilder)
            : base(prefabLoader)
        {
            PathBuilderBuilder = pathBuilderBuilder;
        }

        protected async UniTask<TEntity> LoadPrefab(string assetPath, Transform parent, Func<GameObject, Transform, TEntity> createHandler)
        {
            await LoadPrefab(assetPath);

            var result = createHandler(Prefab, parent);
            
            Debug.Log("Entity built: " + assetPath);

            return result;
        }
    }
}