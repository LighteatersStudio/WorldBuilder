using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.WorldNode;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder
{
    public class WorldNodeProxy : MonoBehaviour
    {
        [SerializeField] private string _nodeName;

        private INodeDownloader _nodeDownloader;
        private WorldNodeBuilder _worldNodeBuilder;
        private WorldNode.WorldNode _worldNode;

        [Inject]
        public void Construct(INodeDownloader nodeDownloader, WorldNodeBuilder worldNodeBuilder)
        {
            _nodeDownloader = nodeDownloader;
            _worldNodeBuilder = worldNodeBuilder;
        }

        public async UniTask Activate()
        {
            await _nodeDownloader.Download(_nodeName);

            _worldNode = await _worldNodeBuilder.Build(_nodeName, transform);
            
            await _worldNode.ActivateLayers();
        }

        protected void OnDestroy()
        {
            _worldNodeBuilder.Release();
        }
    }
}