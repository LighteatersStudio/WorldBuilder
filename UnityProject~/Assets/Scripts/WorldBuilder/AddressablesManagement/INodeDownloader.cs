using System.Threading.Tasks;

namespace BusinessLogic.WorldBuilder.AddressablesManagement
{
    public interface INodeDownloader
    {
        Task Download(string name);
    }
}