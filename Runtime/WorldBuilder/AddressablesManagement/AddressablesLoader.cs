using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BusinessLogic.WorldBuilder.AddressablesManagement
{
    public class AddressablesLoader : IPrefabLoader
    {
        public async UniTask<GameObject> LoadPrefabAsync(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address cannot be null or empty", nameof(address));
            }

            try
            {
                AsyncOperationHandle handle = Addressables.LoadAssetAsync<GameObject>(address);

                var result = await handle.Task;

                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    return (GameObject)result;
                }

                throw new Exception($"Failed to load asset '{address}'. Status: {handle.Status}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error loading asset '{address}': {ex.Message}");
                throw;
            }
        }

        public void ReleaseAsset<T>(T asset) where T : class
        {
            if (asset != null)
            {
                Addressables.Release(asset);
            }
        }
    }
}
