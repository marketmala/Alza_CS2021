using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Logic
{
    public class ProductModule : IProductModule
    {
#nullable enable
        readonly IDataContext context;
        public ProductModule(IDataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<IProduct>?> GetAllProductsAsync()
        {
            try
            {
                var result = await this.context.GetAllProductsAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(IProduct? product, int statusCode, string? error)> GetProductAsync(string id)
        {
            try
            {
                if(!Guid.TryParse(id, out Guid guid))
                {
                    return (null, StatusCodes.Status400BadRequest,  "Invalid product ID.");
                }

                var product = await this.context.GetProductByIdAsync(guid);
                return product != null
                    ? (product, StatusCodes.Status200OK, null)
                    : (null, StatusCodes.Status404NotFound, $"Product with ID {id} not found.");
            }
            catch (Exception e)
            {
                return (null, StatusCodes.Status500InternalServerError, "Unexpected error ocurred.");
            }
        }

        public async Task<(IProduct? product, int statusCode, string? error)> UpdateProductDescriptionAsync(string id, string description)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid guid))
                {
                    return (null, StatusCodes.Status400BadRequest, "Invalid product ID.");
                }

                var product = await this.context.UpdateProductDescriptionAsync(guid, description);
                return product != null
                    ? (product, StatusCodes.Status200OK, null)
                    : (null, StatusCodes.Status404NotFound, $"Product with ID {id} not found.");
            }
            catch(Exception e)
            {
                return (null, StatusCodes.Status500InternalServerError, "Unexpected error during update description.");
            }
        }
    }
}
