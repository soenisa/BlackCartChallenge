using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.Models
{
    public class ShopifyProduct
    {
        public int Id;
        public string Title;
        public IEnumerable<ShopifyVariant> Variants;
        public IEnumerable<ShopifyOption> Options;
    }

    public class ShopifyVariant
    {
        public int Id;
        public string Price;
        public string Grams;
        public int? Inventory_Quantity;
    }

    public class ShopifyOption
    {
        public string Name;
        public IEnumerable<string> Values;
    }
}
