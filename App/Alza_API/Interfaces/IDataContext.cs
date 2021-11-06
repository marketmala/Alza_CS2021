using Alza_API.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Interfaces
{
#nullable enable
    /// <summary>
    /// DataContext Interface
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IProduct>?> GetAllProductsAsync();
        /// <summary>
        /// Returns products with pagination
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IProduct>?> GetProductsPagedAsync(int pageNumber, int pageSize);
        /// <summary>
        /// Returns product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IProduct?> GetProductByIdAsync(Guid id);
        /// <summary>
        /// Update of product description
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<IProduct?> UpdateProductDescriptionAsync(Guid id, string? description);
    }
}
