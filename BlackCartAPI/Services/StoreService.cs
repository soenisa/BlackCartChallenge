using BlackCartAPI.Models;
using BlackCartAPI.Providers.Contracts;
using BlackCartAPI.Services.Contracts;
using BlackCartAPI.TestData;
using BlackCartChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.Services
{
    public class StoreService : IStoreService
    {
        public IPlatformProvider _platformProvider;
        public readonly PlatformProviderResolver _platformProviderResolver;

        public StoreService(PlatformProviderResolver platformProviderResolver, AccountContext accountContext)
        {
            // this can be a scoped service that dynamically sets platform provider based on id passed into 
            _platformProviderResolver = platformProviderResolver;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int id)
        {
            var store = StoresTable.Platforms.Where(x => x.Id == id).FirstOrDefault();
            if(store == null)
            {
                throw new KeyNotFoundException("StoreId not found in StoresTable");
            }
            _platformProvider = _platformProviderResolver(store.Name);
            return await _platformProvider.GetProductsAsync(id);
        }
    }
}
