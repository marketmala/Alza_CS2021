using Alza_API.Interfaces;
using Alza_API.Logic;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Tests.v1
{
#nullable enable
    public class ProductModule_Tests
    {
        readonly IProductModule module;
        public ProductModule_Tests(IDataContext context)
        {
            this.module = new ProductModule(context);
        }

        [Fact]
        public async Task GetAllProducts_Test()
        {
            var products = await module.GetAllProductsAsync();

            Assert.NotNull(products);
            Assert.Equal(15, products?.Count());
        }

        [Theory]
        [InlineData("abcd1234-1234-1234-1234-000000000001", "ProductMock_1", 20, "ImageUriMock_1", StatusCodes.Status200OK, null)]
        [InlineData("abcd1234-1234-1234-1234-000000000501", null, null, null, StatusCodes.Status404NotFound, "Product with ID abcd1234-1234-1234-1234-000000000501 not found.")]
        [InlineData("abc", null, null, null, StatusCodes.Status400BadRequest, "Invalid product ID.")]
        public async Task GetProduct_Test(string id, string? name, int? price, string? imgUri, int statusCode, string? errorMessage)
        {
            var (product, status, error) = await module.GetProductAsync(id);
            Assert.Equal(name, product?.Name);
            Assert.Equal(price != null ? Convert.ToDecimal(price) : null, product?.Price);
            Assert.Equal(imgUri, product?.ImgUri);
            Assert.Equal(statusCode, status);
            Assert.Equal(errorMessage, error);
        }

        [Theory]
        [InlineData("abcd1234-1234-1234-1234-000000000005", "new description", "new description", StatusCodes.Status200OK, null)]
        [InlineData("abcd1234-1234-1234-1234-000000000501", "new description", null, StatusCodes.Status404NotFound, "Product with ID abcd1234-1234-1234-1234-000000000501 not found.")]
        [InlineData("abc", "new description", null, StatusCodes.Status400BadRequest, "Invalid product ID.")]
        public async Task UpdateProductDescription_Test(string id, string description, string? newDescription, int statusCode, string? errorMessage)
        {
            var (product, status, error) = await module.UpdateProductDescriptionAsync(id, description);
            Assert.Equal(newDescription, product?.Description);
            Assert.Equal(statusCode, status);
            Assert.Equal(errorMessage, error);
        }
    }
}
