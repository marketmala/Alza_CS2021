using Alza_API.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Interfaces
{
#nullable enable
    public interface IDataContext
    {
        Task<IEnumerable<IProduct>?> GetAllProductsAsync();
        Task<IProduct?> GetProductByIdAsync(Guid id);
        Task<IProduct?> UpdateProductDescriptionAsync(Guid id, string? description);
    }
}
