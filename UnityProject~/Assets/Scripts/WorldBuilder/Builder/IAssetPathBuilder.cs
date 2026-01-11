namespace BusinessLogic.WorldBuilder.Builder
{
    public interface IAssetPathBuilder
    {
        public string GetAssetPath(params string[] pathParts);
    }
}