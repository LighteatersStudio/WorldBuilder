using BusinessLogic.WorldBuilder.AddressablesManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.Builder
{
    public abstract class PrefabBuilder
    {
        private readonly IPrefabLoader _prefabLoader;
        protected GameObject Prefab { get; private set; }

        protected PrefabBuilder(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
        }

        protected UniTask<GameObject> LoadPrefab(string packageName, string assetName)
        {
            return LoadPrefab(packageName.GetAddressablesPath(assetName));
        }
        protected async UniTask<GameObject> LoadPrefab(string assetName)
        {
            Release();
            
            Prefab = await _prefabLoader.LoadPrefabAsync(assetName);

            CheckPrefab(Prefab);
            
            return Prefab;
        }

        protected virtual void CheckPrefab(GameObject prefab)
        {
            if (prefab == null)
            {
                Debug.Log("prefab not found");
            }
        }
        

        public void Release()
        {
            _prefabLoader.ReleaseAsset(Prefab);
            Prefab = null;
        }
    }
}