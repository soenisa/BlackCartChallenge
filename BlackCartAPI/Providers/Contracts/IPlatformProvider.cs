using BlackCartChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackCartAPI.Providers.Contracts
{
    public delegate IPlatformProvider PlatformProviderResolver(string key);
    public interface IPlatformProvider
    {
        public Task<IEnumerable<Product>> GetProductsAsync(int id);
    }
}
