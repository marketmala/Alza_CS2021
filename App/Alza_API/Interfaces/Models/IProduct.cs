using System;

namespace Alza_API.Interfaces.Models
{
    /// <summary>
    /// Product Interface
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Image URI
        /// </summary>
        public string ImgUri { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
#nullable enable
        /// <summary>
        /// Product description
        /// </summary>
        public string? Description { get; set; }
    }
}
