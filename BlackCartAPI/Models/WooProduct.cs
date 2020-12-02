using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackCartAPI.Models
{
    public class WooProduct
    {
        public int Id;
        public string Name;
        public string Price;
        public int? Stock_Quantity;
        /// <summary>
        /// a list of variation Ids
        /// </summary>
        public IEnumerable<int> Variations;
        /// <summary>
        /// Product weight (kg).
        /// </summary>
        public string Weight;
    }

    public class WooVariant
    {
        // this is the only property we need from the result
        public IEnumerable<WooAttribute> Attributes;
    }

    public class WooAttribute
    {
        public string Name;
        public string Option;
    }
}
