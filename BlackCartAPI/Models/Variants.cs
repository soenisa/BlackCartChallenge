using System.Collections.Generic;

namespace BlackCartChallenge.Models
{
    public class Variation
    {
        /// <summary>
        /// The product this Variant belongs to
        /// </summary>
        public IEnumerable<string> Size { get; set; }
        /// <summary>
        /// Name of the Variant
        /// </summary>
        public IEnumerable<string> Color { get; set; }
    }
}