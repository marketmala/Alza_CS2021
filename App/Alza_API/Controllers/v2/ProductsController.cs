using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Logic;
using Alza_API.Models;
using Alza_API.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alza_API.Controllers.v2
{
    /// <summary>
    /// ProductController V2
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        readonly IProductModule module;

        /// <summary>
        /// ProductController Constructor
        /// </summary>
        /// <param name="module"></param>
        public ProductsController(IProductModule module)
        {
            this.module = module;
        }

        /// <summary>
        /// Returns paged list of products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IProductsPaged))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProductsPagedAsync([FromQuery]Footer request)
        {
            var productsPaged = await module.GetProductsPagedAsync(request);
            return productsPaged?.Products != null
                ? Ok(productsPaged)
                : StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
