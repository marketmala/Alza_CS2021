using Alza_API.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Interfaces
{
#nullable enable
    /// <summary>
    /// ProductModule Interface
    /// </summary>
    public interface IProductModule
    {
        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IProduct>?> GetAllProductsAsync();        
        /// <summary>
        /// Returns paged list of products
        /// </summary>
        /// <returns></returns>
        Task<IProductsPaged> GetProductsPagedAsync(IFooter footer);
        /// <summary>
        /// Returns product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(IProduct? product, int statusCode, string? error)> GetProductAsync(string id);
        /// <summary>
        /// Update of product description
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<(IProduct? product, int statusCode, string? error)> UpdateProductDescriptionAsync(string id, string description);
    }
}
