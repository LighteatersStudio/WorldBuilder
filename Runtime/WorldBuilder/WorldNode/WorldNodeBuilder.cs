using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.Builder;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.WorldNode
{
    public class WorldNodeBuilder : ComponentBuilder<WorldNode>
    {
        private const string WorldNodeName = "WorldNode";
        
        private readonly WorldNodeFactory _factory;

        public WorldNodeBuilder(AddressablesLoader prefabLoader, WorldNodeFactory factory)
            : base(prefabLoader)
        {
            _factory = factory;
        }

        public async UniTask<WorldNode> Build(string bundleName, Transform parent)
        {
            await LoadComponent(bundleName, WorldNodeName);

            var result = _factory.Create(bundleName, Component, parent);

            Debug.Log("WorldNode built: " + bundleName);

            return result;
        }
    }
}