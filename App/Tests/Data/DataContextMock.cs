using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Data
{
#nullable enable
    public class DataContextMock : IDataContext
    {
        List<IProduct>? Products;
        public DataContextMock()
        {
            InitializeProductCollection();
        }

        public Task<IEnumerable<IProduct>?> GetAllProductsAsync()
        {
            return Task.FromResult(Products?.AsEnumerable());
        }

        public Task<IProduct?> GetProductByIdAsync(Guid id)
        {
            var product = Products?.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<IProduct>?> GetProductsPagedAsync(int pageNumber, int pageSize)
        {
            var products = Products?
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return Task.FromResult(products);
        }

        public Task<IProduct?> UpdateProductDescriptionAsync(Guid id, string? description)
        {
            var product = Products?.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Description = description;
            }

            return Task.FromResult(product);
        }

        private void InitializeProductCollection()
        {
            this.Products = new List<IProduct>();
            for (int i = 1; i <= 15; i++)
            {
                this.Products.Add(new Product
                {
                    Id = new Guid($"abcd1234-1234-1234-1234-{i.ToString().PadLeft(12, '0')}"),
                    Name = $"ProductMock_{i}",
                    ImgUri = $"ImageUriMock_{i}",
                    Description = null,
                    Price = i * 20
                });
            }
        }
    }
}
