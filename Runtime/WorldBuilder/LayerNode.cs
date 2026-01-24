using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.EntityNode;
using Zenject;

namespace BusinessLogic.WorldBuilder
{
    public class LayerNode : EntityNode<PlaceholderNodeController, AddressablesLoader>
    {
        protected override string GroupName => "Layers";

        [Inject]
        public void Construct(EntityBuilder<PlaceholderNodeController, AddressablesLoader> builder)
        {
            ConstructBase(builder);
        }
    }
}