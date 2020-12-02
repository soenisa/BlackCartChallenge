using BlackCartAPI.Models;
using BlackCartAPI.Providers;
using BlackCartChallenge.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{
    public class WooCommerceProviderTests
    {
        private WooCommerceProvider wooProvider;

        private AccountContext TestContext_Woo = new AccountContext()
        {
            PlatformId = 2,
            ConsumerKey = "key",
            ConsumerSecret = "secret"
        };

        private Product StoreId_2_Product_1 = new Product()
        {
            ProductId = 557,
            Name = "Product A",
            Price = 21.99,
            InventoryLevel = 23,
            Weight = 27.3,
            Variations = new Variation {
                Size = new List<string> {
                    "Medium",
                    "Large"
                },
                Color = new List<string> {
                "Black",
                "Green"
                }
            }
        };

        [SetUp]
        public void Setup()
        {
            wooProvider = new WooCommerceProvider(TestContext_Woo);
        }

        [Test]
        public async Task StoreWithProducts_ShouldReturnCorrectProducts()
        {
            var result = await wooProvider.GetProductsAsync(2);
            var list = result.ToList();
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.AreEqual(list[0].ProductId, StoreId_2_Product_1.ProductId);
            Assert.AreEqual(list[0].Name, StoreId_2_Product_1.Name);
            Assert.AreEqual(list[0].Price, StoreId_2_Product_1.Price);
            Assert.AreEqual(list[0].InventoryLevel, StoreId_2_Product_1.InventoryLevel);
            Assert.AreEqual(list[0].Weight, StoreId_2_Product_1.Weight);
            Assert.AreEqual(list[0].Variations.Color, StoreId_2_Product_1.Variations.Color);
            Assert.AreEqual(list[0].Variations.Size, StoreId_2_Product_1.Variations.Size);
        }

        [Test]
        public async Task StoreWithEmptyProducts_ShouldReturnNoProducts()
        {
            var result = await wooProvider.GetProductsAsync(3);
            var list = result.ToList();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task NonExistentStore_ShouldThrowException()
        {
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await wooProvider.GetProductsAsync(0));
            Assert.AreEqual("StoreId not found.", ex.Message);
        }
    }
}