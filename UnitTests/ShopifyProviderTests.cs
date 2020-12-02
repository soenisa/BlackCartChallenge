using BlackCartAPI.Models;
using BlackCartAPI.Providers;
using BlackCartChallenge.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ShopifyProviderTests
    {
        private ShopifyProvider shopifyProvider;
        
        private Product StoreId_1_Product_1 = new Product()
        {
            ProductId = 543,
            Name = "Product Q",
            Price = 20.19,
            InventoryLevel = 5,
            Weight = 0.599,
            Variations = new Variation {
                Size = new List<string> {
                    "Medium"
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
            shopifyProvider = new ShopifyProvider();
        }

        [Test]
        public async Task StoreWithProducts_ShouldReturnCorrectProducts()
        {
            var result = await shopifyProvider.GetProductsAsync(2);
            var list = result.ToList();
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(list[0].ProductId, StoreId_1_Product_1.ProductId);
            Assert.AreEqual(list[0].Name, StoreId_1_Product_1.Name);
            Assert.AreEqual(list[0].Price, StoreId_1_Product_1.Price);
            Assert.AreEqual(list[0].InventoryLevel, StoreId_1_Product_1.InventoryLevel);
            Assert.AreEqual(list[0].Weight, StoreId_1_Product_1.Weight);
            Assert.AreEqual(list[0].Variations.Color, StoreId_1_Product_1.Variations.Color);
            Assert.AreEqual(list[0].Variations.Size, StoreId_1_Product_1.Variations.Size);
        }
    }
}