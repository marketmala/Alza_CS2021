using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Models.DB;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Logic
{
    /// <summary>
    /// Class for retrieve and manipulation with products
    /// </summary>
    public partial class ProductModule : IProductModule
    {
#nullable enable
        readonly IDataContext context;
        readonly ILogger logger = Log.ForContext<ProductModule>();

        /// <summary>
        /// ProductModule Contructor
        /// </summary>
        /// <param name="context"></param>
        public ProductModule(IDataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IProduct>?> GetAllProductsAsync()
        {
            try
            {
                var result = await this.context.GetAllProductsAsync();
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "GetAllProductsAsync");
                return null;
            }
        }

        /// <summary>
        /// Returns product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IProduct?> GetProductAsync(string id)
        {
            try
            {
                if(!Guid.TryParse(id, out Guid guid))
                {
                    return null;
                }

                var product = await this.context.GetProductByIdAsync(guid);
                return product != null
                    ? product
                    : null;
            }
            catch (Exception e)
            {
                logger.Error(e, "GetProductAsync");
                return null;
            }
        }

        /// <summary>
        /// Update of product description
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<IProduct?> UpdateProductDescriptionAsync(string id, string description)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid guid))
                {
                    return null;
                }

                var product = await this.context.UpdateProductDescriptionAsync(guid, description);
                return product != null
                    ? product
                    : null; 
            }
            catch(Exception e)
            {
                logger.Error(e, "UpdateProductDescriptionAsync");
                return null;
            }
        }
    }
}
