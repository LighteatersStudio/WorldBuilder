using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder.WorldNode
{
    public class WorldNodeFactory : PlaceholderFactory<string, WorldNode, Transform, WorldNode>
    {
    }
}