namespace BusinessLogic.WorldBuilder.AddressablesManagement
{
    public static class StringExtensions
    {
        public static string GetAddressablesPath(this string packageName,  string assetName)
        {
            return $"{packageName}/{assetName}";
        }
    }
}