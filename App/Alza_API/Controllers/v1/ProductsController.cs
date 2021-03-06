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
        /// Returns list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IProduct>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var result = await module.GetAllProductsAsync();
            return result != null
                ? Ok(result)
                : StatusCode(StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Returns product by ID
        /// </summary>
        /// <param name="id">ID of product</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [ValidateProductsParametersAttribute]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IProduct))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProductAsync([Required]string id)
        {
            var product = await module.GetProductAsync(id);
            return product != null
                ? Ok(product)
                : StatusCode(StatusCodes.Status404NotFound, $"Product with ID {id} not found.");
        }

        /// <summary>
        /// Update of product description
        /// </summary>
        /// <param name="id">ID of product</param>
        /// <param name="description">New description</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [ValidateProductsParametersAttribute]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProductAsync([Required]string id, string description)
        {
            var product = await module.UpdateProductDescriptionAsync(id, description);
            return product != null
                ? Ok()
                : StatusCode(StatusCodes.Status404NotFound, $"Product with ID {id} not found.");
        }
    }
}
