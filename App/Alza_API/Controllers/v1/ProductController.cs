using Alza_API.Interfaces.Models;
using Alza_API.Logic;
using Alza_API.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ProductModule module;

        public ProductController(DataContext context)
        {
            this.module = new ProductModule(context);
        }

        [HttpGet("GetAllProductsAsync")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IProduct>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var result = await module.GetAllProductsAsync();
            return result != null
                ? Ok(result)
                : BadRequest(null);
        }

        [HttpGet("GetProductAsync")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IProduct))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProductAsync(string id)
        {
            var (product, errorMessage) = await module.GetProductAsync(id);
            return string.IsNullOrEmpty(errorMessage) 
                ? Ok(product)
                : BadRequest(errorMessage);
        }

        [HttpPost("UpdateProductAsync")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> UpdateProductAsync()
        {
            return Ok();
        }
    }
}
