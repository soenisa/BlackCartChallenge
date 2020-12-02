using BlackCartAPI.Models;
using BlackCartAPI.Providers.Contracts;
using BlackCartAPI.TestData.WooCommerce;
using BlackCartChallenge.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.Providers
{
    public class WooCommerceProvider : IPlatformProvider
    {
        private readonly AccountContext _accountContext;
        public WooCommerceProvider(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int id)
        {
            // retrieve products
            // pretend I make an API call here to retrieve data from Woo
            // commonly rest libraries will take an class to cast the json response to
            // thus the test data from woo is returned as a Woo shaped object
            //WooProduct apiResponse = await $"https://example.com/wp-json/wc/v3/products/{id}"
            //    .WithBasicAuth(_accountContext.ConsumerKey, _accountContext.ConsumerSecret)
            //    .GetJsonAsync<WooProduct>();

            var apiResponse = WooTestData.GetProductsByStoreId(id);

            List<Product> result = new List<Product>();
            foreach(var product in apiResponse)
            {
                // retrieve variants for each product
                //WooProduct apiResponse = await $"https://example.com/wp-json/wc/v3/products/{product.Id}/variations"
                //    .WithBasicAuth(_accountContext.ConsumerKey, _accountContext.ConsumerSecret)
                //    .GetJsonAsync<WooProduct>();
                result.Add(new Product(product, WooTestData.GetVariantsByProductId(product.Id)));
            }


            return result;
        }
    }
}
