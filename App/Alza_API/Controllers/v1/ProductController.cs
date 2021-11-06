using Alza_API.Interfaces;
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
    /// <summary>
    /// ProductController V1
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly IProductModule module;

        /// <summary>
        /// ProductController Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProductController(DataContext context)
        {
            this.module = new ProductModule(context);
        }

        /// <summary>
        /// Returns list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductsAsync")]
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

        /// <summary>
        /// Returns product by ID
        /// </summary>
        /// <param name="id">ID of product</param>
        /// <returns></returns>
        [HttpGet("GetProductAsync")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IProduct))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProductAsync([Required]string id)
        {
            var (product, statusCode, errorMessage) = await module.GetProductAsync(id);
            return string.IsNullOrEmpty(errorMessage) 
                ? Ok(product)
                : StatusCode(statusCode, errorMessage);
        }

        /// <summary>
        /// Update of product description
        /// </summary>
        /// <param name="id">ID of product</param>
        /// <param name="description">New description</param>
        /// <returns></returns>
        [HttpPost("UpdateProductAsync")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProductAsync([Required]string id, string description)
        {
            var (product, statusCode, errorMessage) = await module.UpdateProductDescriptionAsync(id, description);
            return product != null && product.Description == description
                ? Ok()
                : StatusCode(statusCode, errorMessage);
        }
    }
}
