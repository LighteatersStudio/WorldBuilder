using System.Threading.Tasks;

namespace BusinessLogic.WorldBuilder.AddressablesManagement
{
    public class FakeNodeDownloader : INodeDownloader
    {
        public Task Download(string name)
        {
            return Task.CompletedTask;
        }
    }
}