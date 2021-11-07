using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Models;
using System;
using System.Threading.Tasks;

namespace Alza_API.Logic
{
    public partial class ProductModule : IProductModule
    {
        /// <summary>
        /// Returns paged list of products
        /// </summary>
        /// <returns></returns>
        public async Task<IProductsPaged> GetProductsPagedAsync(IFooter footer) 
        {
            var pageNumber = footer?.PageNumber > 0 ? (int)footer.PageNumber : 1;
            var pageSize = footer?.PageSize > 0 ? (int)footer.PageSize : 10;

            var result = new ProductsPaged
            {
                Footer = new Footer
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };

            try
            {
                result.Products = await this.context.GetProductsPagedAsync(pageNumber, pageSize);
            }
            catch (Exception e)
            {
                logger.Error(e, "GetProductsPagedAsync");
            }

            return result;
        }

    }
}
