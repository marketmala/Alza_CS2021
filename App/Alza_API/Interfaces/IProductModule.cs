using Alza_API.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Interfaces
{
    public interface IProductModule
    {
        Task<IEnumerable<IProduct>> GetAllProductsAsync();
        Task<(IProduct product, string error)> GetProductAsync(string id);
        Task<bool> UpdateProductDescriptionAsync(string id);
    }
}
