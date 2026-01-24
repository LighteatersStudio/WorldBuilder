using System.Threading.Tasks;
using BusinessLogic.WorldBuilder.AddressablesManagement;
using Cysharp.Threading.Tasks;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public abstract class EntityNode<TEntity, TPrefabLoader> : EntityNodeBase<TEntity> 
        where TPrefabLoader : IPrefabLoader
    {
        private EntityBuilder<TEntity, TPrefabLoader> _builder;
        
        protected void ConstructBase(EntityBuilder<TEntity, TPrefabLoader> builder)
        {
            _builder = builder;
        }
        
        protected override Task<TEntity> CreateEntity()
        {
            return _builder.Build(GroupName, AssetName, transform).AsTask();
        }

        protected override void DeactivateInternal()
        {
            _builder.Release();
        }
    }
}