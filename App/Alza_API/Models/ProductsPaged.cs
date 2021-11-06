using Alza_API.Interfaces.Models;
using System.Collections.Generic;

namespace Alza_API.Models
{
    /// <summary>
    /// List of products with pagination
    /// </summary>
    public class ProductsPaged : IProductsPaged
    {
        /// <summary>
        /// List of products
        /// </summary>
#nullable enable
        public IEnumerable<IProduct>? Products { get; set; }
#nullable disable
        /// <summary>
        /// Footer with pagination
        /// </summary>
        public IFooter Footer { get; set; }
    }
}
