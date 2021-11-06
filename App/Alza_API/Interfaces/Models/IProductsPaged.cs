using System.Collections.Generic;

namespace Alza_API.Interfaces.Models
{
    /// <summary>
    /// List of products with pagination
    /// </summary>
    public interface IProductsPaged
    {
        /// <summary>
        /// List of products
        /// </summary>
#nullable enable
        IEnumerable<IProduct>? Products { get; set; }

        /// <summary>
        /// Footer with pagination
        /// </summary>
        IFooter Footer { get; set; }
    }
}
