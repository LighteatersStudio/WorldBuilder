using BusinessLogic.WorldBuilder.AddressablesManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.Builder
{

    public abstract class ComponentBuilder<TComponent> : PrefabBuilder where  TComponent : Component
    {
        protected TComponent Component => Prefab.GetComponent<TComponent>();

        protected ComponentBuilder(AddressablesLoader prefabLoader)
        : base(prefabLoader)
        {
        }
        
        protected async UniTask<TComponent> LoadComponent(string packageName, string assetName)
        {
            await LoadPrefab(packageName.GetAddressablesPath(assetName));
            return Component;
        }

        protected override void CheckPrefab(GameObject prefab)
        {
            if (!Prefab.TryGetComponent<TComponent>( out var asset))
            {
                Debug.LogError($"Didn't find component({typeof(TComponent)}) on prefab: {prefab.name}");
            }
        }
    }
}