using Alza_API.Interfaces.Models;
using Alza_API.Logic;
using Alza_API.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var result = await module.GetAllProductsAsync();
            return result != null
                ? Ok(result)
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetProductAsync")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IProduct))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProductAsync([Required]string id)
        {
            var (product, statusCode, errorMessage) = await module.GetProductAsync(id);
            return string.IsNullOrEmpty(errorMessage) 
                ? Ok(product)
                : StatusCode(statusCode, errorMessage);
        }

        [HttpPost("UpdateProductAsync")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProductAsync([Required]string id, string description)
        {
            var (success, statusCode, errorMessage) = await module.UpdateProductDescriptionAsync(id, description);
            return success
                ? Ok()
                : StatusCode(statusCode, errorMessage);
        }
    }
}
