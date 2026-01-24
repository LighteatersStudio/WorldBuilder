using System.Text;

namespace BusinessLogic.WorldBuilder.Builder
{
    public class BundleName
    {
        public string Id { get; }
        
        public BundleName(string id)
        {
            Id = id;
        }

        public string GetAssetPath(params string[] pathsElements)
        {
            return Id.GetAssetPath(pathsElements);
        }
    }
}