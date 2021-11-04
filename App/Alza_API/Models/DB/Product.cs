using Alza_API.Interfaces.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Alza_API.Models.DB
{
    public class Product : IProduct
    {
        [Key]
        [Required(ErrorMessage = "Missing required attribute: Id.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Missing required attribute: Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Missing required attribute: ImgUri.")]
        public string ImgUri { get; set; }

        [Required(ErrorMessage = "Missing required attribute: Price.")]
        public decimal Price { get; set; }

        public string? Description { get; set; }

    }
}
