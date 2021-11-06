using Alza_API.Interfaces;
using Alza_API.Interfaces.Models;
using Alza_API.Logic;
using Alza_API.Models;
using Alza_API.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alza_API.Controllers.v2
{
    /// <summary>
    /// ProductController V2
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]/v2")]
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
        /// Returns paged list of products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetProductsAsync")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IProductsPaged))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProductsPagedAsync([FromQuery]Footer request)
        {
            var productsPaged = await module.GetProductsPagedAsync(request);
            return productsPaged?.Products != null
                ? Ok(productsPaged)
                : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
