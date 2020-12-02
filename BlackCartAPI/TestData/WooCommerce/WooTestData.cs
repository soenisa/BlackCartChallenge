using BlackCartAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlackCartAPI.TestData.WooCommerce
{
    public static class WooTestData
    {
        public static Dictionary<int, IEnumerable<WooProduct>> Products = new Dictionary<int, IEnumerable<WooProduct>>()
        {
            { 2, new List<WooProduct>() {
                    new WooProduct()
                    {
                        Id = 557,
                        Name = "Product A",
                        Price = "21.99",
                        Stock_Quantity = 23,
                        Variations = new List<int>() {
                            111,
                            112,
                            113
                        },
                        Weight = "27.3"
                    },
                    new WooProduct()
                    {
                        Id = 111,
                        Name = "Product B",
                        Price = "24",
                        Stock_Quantity = 23,
                        Variations = new List<int>() {
                            222
                        },
                        Weight = null
                    },
                    new WooProduct()
                    {
                        Id = 3,
                        Name = "Product C",
                        Price = "5",
                        Stock_Quantity = 23,
                        Variations = new List<int>() {
                            333
                        },
                        Weight = "64.00"
                    },
                    new WooProduct()
                    {
                        Id = 4,
                        Name = "Product D",
                        Price = "15.50",
                        Stock_Quantity = 23,
                        Variations = new List<int>() {
                            444
                        },
                        Weight = "0.00"
                    }
                }
            },
            { 3,
                new List<WooProduct>() {}
            }
        };

        public static IEnumerable<WooProduct> GetProductsByStoreId(int storeId)
        {
            if (!Products.ContainsKey(storeId))
            {
                throw new KeyNotFoundException("StoreId not found.");
            };
      
            return Products[storeId];
        }

        public static Dictionary<int, IEnumerable<WooVariant>> Variants = new Dictionary<int, IEnumerable<WooVariant>>()
        {
            { 557, new List<WooVariant>() {
                new WooVariant {
                    Attributes = new List<WooAttribute>() {
                        new WooAttribute { Name = "Color", Option = "Black" },
                        new WooAttribute { Name = "Size", Option = "Medium" },
                    }
                },
                new WooVariant {
                    Attributes = new List<WooAttribute>() {
                        new WooAttribute { Name = "Color", Option = "Green" },
                        new WooAttribute { Name = "Size", Option = "Large" },
                    }
                }
            } },
            { 111, new List<WooVariant>() {
                new WooVariant {
                    Attributes = new List<WooAttribute>() {
                        new WooAttribute { Name = "Color", Option = "White" },
                        new WooAttribute { Name = "Size", Option = "Small" },
                    }
                },
                new WooVariant {
                    Attributes = new List<WooAttribute>() {
                        new WooAttribute { Name = "Color", Option = "Green" },
                        new WooAttribute { Name = "Size", Option = "Medium" },
                    }
                }
            } }
        };

        public static IEnumerable<WooVariant> GetVariantsByProductId(int productId)
        {
            if (!Variants.ContainsKey(productId))
            {
                return Enumerable.Empty<WooVariant>();
            };

            return Variants[productId];
        }
    }
}
