using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.AddressablesManagement
{
    public interface IPrefabLoader
    {
        UniTask<GameObject> LoadPrefabAsync(string address);
        void ReleaseAsset<T>(T asset) where T : class;
    }
}