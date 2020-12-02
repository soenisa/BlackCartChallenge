using BlackCartAPI.Models;
using BlackCartAPI.Providers.Contracts;
using BlackCartChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.Providers
{
    public class ShopifyProvider : IPlatformProvider
    {
        public async Task<IEnumerable<Product>> GetProductsAsync(int id)
        {
            // pretend I make an API call here to retrieve data from Woo
            // commonly rest libraries will take an class to cast the json response to
            // thus the test data from woo is returned as a Woo shaped object
            //WooProduct apiResponse = await $"https://example.com/wp-json/wc/v3/products/{id}"
            //    .WithBasicAuth("consumer_key", "consumer_secret")
            //    .GetJsonAsync<ShopifyProduct>();

            var apiResponse = new List<ShopifyProduct>() {
                new ShopifyProduct()
                {
                    Id = 543,
                    Title = "Product Q",
                    Variants = new List<ShopifyVariant>() {
                        new ShopifyVariant() { Price = "20.19", Inventory_Quantity = 5, Grams = "599" },
                        new ShopifyVariant() { Price = "25.99", Inventory_Quantity = 10, Grams = "750" }
                    },
                    Options = new List<ShopifyOption>()
                    {
                        new ShopifyOption() { Name = "Color", Values = new List<string>() { "Black", "Green" } },
                        new ShopifyOption() { Name = "Size", Values = new List<string>() { "Medium" } }
                    }
                },
                new ShopifyProduct()
                {
                    Id = 799,
                    Title = "Product R",
                      Variants = new List<ShopifyVariant>() {
                        new ShopifyVariant() { Price = "100", Inventory_Quantity = 17, Grams = "2000" }
                    },
                    Options = new List<ShopifyOption>()
                    {
                        new ShopifyOption() { Name = "Color", Values = new List<string>() { "Green" } },
                        new ShopifyOption() { Name = "Size", Values = new List<string>() { "Large" } }
                    }
                },
                new ShopifyProduct()
                {
                    Id = 899,
                    Title = "Product S",
                      Variants = new List<ShopifyVariant>() {
                        new ShopifyVariant() { Price = "49.00", Inventory_Quantity = 50, Grams = "3000" },
                        new ShopifyVariant() { Price = "60.00", Inventory_Quantity = 34, Grams = "3700" },
                        new ShopifyVariant() { Price = "66.00", Inventory_Quantity = 3, Grams = "3900" }
                    },
                    Options = new List<ShopifyOption>()
                    {
                        new ShopifyOption() { Name = "Color", Values = new List<string>() { "Green", "Pink", "White" } },
                        new ShopifyOption() { Name = "Size", Values = new List<string>() { "Large" } }
                    }
                },
            };

            return apiResponse.Select(x => new Product(x));
        }
    }
}
