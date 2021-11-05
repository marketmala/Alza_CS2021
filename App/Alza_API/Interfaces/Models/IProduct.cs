﻿using System;

namespace Alza_API.Interfaces.Models
{
#nullable enable
    public interface IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
