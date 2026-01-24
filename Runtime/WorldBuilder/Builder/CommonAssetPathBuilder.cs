using BusinessLogic.WorldBuilder.EntityNode;

namespace BusinessLogic.WorldBuilder.Builder
{
    public class CommonAssetPathBuilder : IAssetPathBuilder
    {
        private readonly BundleName _bundleName;

        public CommonAssetPathBuilder(BundleName bundleName)
        {
            _bundleName = bundleName;
        }
        
        public string GetAssetPath(params string[] pathParts)
        {
            return _bundleName.GetAssetPath(pathParts);
        }
    }
}