using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alza_API.Models.DB
{
    /// <summary>
    /// DataContext
    /// </summary>
    public class DataContext : DbContext, IDataContext
    {
        /// <summary>
        /// DataContext Constructor
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// Dataset of products
        /// </summary>
        public DbSet<Product> Products { get; set; }

#nullable enable
        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IProduct>?> GetAllProductsAsync()
        {
            return await this.Products.OrderBy(x => x.Name).ToListAsync();
        }

        /// <summary>
        /// Returns products with pagination
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IProduct>?> GetProductsPagedAsync(int pageNumber, int pageSize)
        {
            return await this.Products
                .OrderBy(x => x.Name)
                .Skip((pageNumber - 1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Returns product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IProduct?> GetProductByIdAsync(Guid id)
        {
            return await this.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Update of product description
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<IProduct?> UpdateProductDescriptionAsync(Guid id, string? description)
        {
            var product = await this.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product != null)
            {
                product.Description = description;
                await this.SaveChangesAsync();
            }
            return product;
        }
    }
}
