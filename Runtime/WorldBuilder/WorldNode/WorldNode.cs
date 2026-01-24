using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.WorldNode
{
    public class WorldNode : MonoBehaviour
    {
        private List<LayerNode>  _layers = new();

        private void TryInitLayers()
        {
            if (_layers.Count != 0)
            {
                return;
            }
            
            _layers = transform.GetComponentsInChildren<LayerNode>(true).ToList();
        }
        
        public async UniTask ActivateLayers()
        {
            TryInitLayers();
            
            foreach (var layerNode in _layers)
            {
                await layerNode.Activate();
            }
        }

        public void Deactivate()
        {
        }
    }
}