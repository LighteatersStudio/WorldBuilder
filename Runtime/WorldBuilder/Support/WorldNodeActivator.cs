using UnityEngine;

namespace BusinessLogic.WorldBuilder.Support
{
    public class WorldNodeActivator : MonoBehaviour
    {
        [SerializeField] private WorldNodeProxy worldNodeProxy;

        protected void Start()
        {
            _ = worldNodeProxy.Activate();
        }
    }
}