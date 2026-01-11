using System.Threading.Tasks;
using BusinessLogic.WorldBuilder.AddressablesManagement;
using Cysharp.Threading.Tasks;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public abstract class EntityNode<TEntity, TPrefabLoader, TContext> : EntityNodeBase<TEntity>
        where TContext : INodeContext where TPrefabLoader : IPrefabLoader
    {
        protected abstract TContext Context { get; }
        private EntityBuilder<TEntity, TPrefabLoader, TContext> _builder;

        protected void ConstructBase(EntityBuilder<TEntity, TPrefabLoader, TContext> builder)
        {
            _builder = builder;
        }

        protected override Task<TEntity> CreateEntity()
        {
            Context.Verify(str => $"{name}/{str}");

            return _builder.Build(GroupName, AssetName, transform, Context).AsTask();
        }

        protected override void DeactivateInternal()
        {
            _builder.Release();
        }
    }
}