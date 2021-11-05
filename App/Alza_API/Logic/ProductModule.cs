using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Models.DB;
using Microsoft.AspNetCore.Http;
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
                var result = await this.context.Products.OrderBy(x => x.Name).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(IProduct product, int statusCode,  string error)> GetProductAsync(string id)
        {
            try
            {
                if(!Guid.TryParse(id, out Guid guid))
                {
                    return (null, StatusCodes.Status400BadRequest,  "Invalid product ID.");
                }

                var product = await this.context.Products.FirstOrDefaultAsync(x => x.Id == guid);
                return product != null
                    ? (product, StatusCodes.Status200OK, null)
                    : (product, StatusCodes.Status400BadRequest, $"Product with ID {id} not found.");
            }
            catch (Exception e)
            {
                return (null, StatusCodes.Status500InternalServerError, "Unexpected error ocurred.");
            }
        }

        public async Task<(bool success, int statusCode, string error)> UpdateProductDescriptionAsync(string id, string description)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid guid))
                {
                    return (false, StatusCodes.Status400BadRequest, "Invalid product ID.");
                }

                var product = await this.context.Products.FirstOrDefaultAsync(x => x.Id == guid);
                if(product != null)
                {
                    product.Description = description;
                    await context.SaveChangesAsync();
                }
                else
                {
                    return (false, StatusCodes.Status400BadRequest, $"Product with ID {id} not found.");
                }

                return (true, StatusCodes.Status200OK, null);
            }
            catch(Exception e)
            {
                return (false, StatusCodes.Status500InternalServerError, "Unexpected error during update description.");
            }
        }
    }
}
