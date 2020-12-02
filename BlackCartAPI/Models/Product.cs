using BlackCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackCartChallenge.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(ShopifyProduct product)
        {
            ProductId = product.Id;
            Name = product.Title;
            var topVariant = product.Variants.FirstOrDefault();
            Price = ConvertToNullDouble(topVariant.Price);
            InventoryLevel = product.Variants.FirstOrDefault().Inventory_Quantity;
            Variations = new Variation();
            Variations.Size = product.Options.Where(x => x.Name == "Size").FirstOrDefault().Values;
            Variations.Color = product.Options.Where(x => x.Name == "Color").FirstOrDefault().Values;
            var weightGrams = ConvertToNullDouble(product.Variants.FirstOrDefault().Grams);
            Weight = weightGrams == null ? null : weightGrams / 1000;
        }

        public Product(WooProduct product, IEnumerable<WooVariant> variants)
        {
            ProductId = product.Id;
            Name = product.Name;
            Price = ConvertToNullDouble(product.Price);
            InventoryLevel = product.Stock_Quantity;
            Weight = ConvertToNullDouble(product.Weight);
            Variations = new Variation();
            var attributes = variants.SelectMany(x => x.Attributes);
            Variations.Color = attributes.Where(x => x.Name.Equals("Color")).Select(x => x.Option);
            Variations.Size = attributes.Where(x => x.Name.Equals("Size")).Select(x => x.Option);
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? InventoryLevel { get;set; }
        public double? Weight { get; set; }
        public Variation Variations { get; set; }

        private double? ConvertToNullDouble(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? null
                : (double?) double.Parse(value);
        }
    }
}
