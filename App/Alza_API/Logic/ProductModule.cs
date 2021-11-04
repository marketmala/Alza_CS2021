using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alza_API.Logic
{
    public class ProductModule : IProductModule
    {
        readonly DataContext context;
        public ProductModule(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<IProduct>> GetAllProductsAsync()
        {
            try
            {
                var result = await this.context.Products.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(IProduct product, string error)> GetProductAsync(string id)
        {
            try
            {
                if(!Guid.TryParse(id, out Guid guid))
                {
                    return (null, "Invalid product ID.");
                }

                var product = await this.context.Products.FirstOrDefaultAsync(x => x.Id == guid);
                return product != null
                    ? (product, null)
                    : (product, $"Product with ID {id} not found.");
            }
            catch (Exception e)
            {
                return (null, "Unexpected error ocurred.");
            }
        }

        public Task<bool> UpdateProductDescriptionAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
