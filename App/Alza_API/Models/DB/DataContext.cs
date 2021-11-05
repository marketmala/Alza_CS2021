using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alza_API.Models.DB
{
#nullable enable
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public async Task<IEnumerable<IProduct>?> GetAllProductsAsync()
        {
            return await this.Products.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IProduct?> GetProductByIdAsync(Guid id)
        {
            return await this.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

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
