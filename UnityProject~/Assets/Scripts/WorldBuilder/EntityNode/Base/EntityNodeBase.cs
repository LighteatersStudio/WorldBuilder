using System.Threading.Tasks;
using UnityEngine;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public abstract class EntityNodeBase<TEntity> : MonoBehaviour
    {
        [field: SerializeField] protected string AssetName { get; private set; }
        [SerializeField] private bool _activateOnStart = true;

        protected virtual string GroupName => string.Empty;
        
        protected TEntity Entity { get; private set; }

        protected virtual void Start()
        {
            if(_activateOnStart)
            {
                _ = Activate();
            }
        }
        
        public async Task Activate()
        {
            Entity = await CreateEntity();
        }

        protected abstract Task<TEntity> CreateEntity();
        
        public void Deactivate()
        {
            DeactivateInternal();
            Entity = default;
        }

        protected abstract void DeactivateInternal();

    }
}