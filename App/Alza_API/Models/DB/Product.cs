using Alza_API.Interfaces.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Alza_API.Models.DB
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Product ID
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Missing required attribute: Id.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Required(ErrorMessage = "Missing required attribute: Name.")]
        public string Name { get; set; }

        /// <summary>
        /// Image URI
        /// </summary>
        [Required(ErrorMessage = "Missing required attribute: ImgUri.")]
        public string ImgUri { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required(ErrorMessage = "Missing required attribute: Price.")]
        public decimal Price { get; set; }

#nullable enable
        /// <summary>
        /// Product description
        /// </summary>
        public string? Description { get; set; }

    }
}
