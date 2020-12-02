using BlackCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.TestData
{
    public static class StoresTable
    {
        public static IEnumerable<Platform> Platforms = new List<Platform>()
        {
            new Platform { Id = 1, Name = "shopify"},
            new Platform { Id = 2, Name = "woocommerce"}
        };
    }
}
