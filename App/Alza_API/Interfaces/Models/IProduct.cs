using System;

namespace Alza_API.Interfaces.Models
{
    public interface IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public decimal Price { get; set; }
#nullable enable
        public string? Description { get; set; }
    }
}
