using System.Text;

namespace BusinessLogic.WorldBuilder.Builder
{
    public static class AssetPathBuilderExtensions
    {
        public static string GetAssetPath(this string main, params string[] pathsElements)
        {
            StringBuilder result = new StringBuilder(main);
            foreach (var element in pathsElements)
            {
                if (string.IsNullOrEmpty(element))
                {
                    continue;
                }
                result.Append("/" + element);
            }

            return result.ToString();
        }
    }
}