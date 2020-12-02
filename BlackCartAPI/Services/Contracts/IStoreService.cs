using BlackCartChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackCartAPI.Services.Contracts
{
    public interface IStoreService
    {
        public Task<IEnumerable<Product>> GetProductsAsync (int id);
    }
}
