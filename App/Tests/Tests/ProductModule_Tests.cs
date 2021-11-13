using Alza_API.Interfaces;
using Alza_API.Logic;
using Alza_API.Models;
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
        [InlineData("abcd1234-1234-1234-1234-000000000001", "ProductMock_1", 20, "ImageUriMock_1")]
        [InlineData("abcd1234-1234-1234-1234-000000000501", null, null, null)]
        [InlineData("abc", null, null, null)]
        public async Task GetProduct_Test(string id, string? name, int? price, string? imgUri)
        {
            var product = await module.GetProductAsync(id);
            Assert.Equal(name, product?.Name);
            Assert.Equal(price != null ? Convert.ToDecimal(price) : null, product?.Price);
            Assert.Equal(imgUri, product?.ImgUri);
        }

        [Theory]
        [InlineData("abcd1234-1234-1234-1234-000000000005", "new description", "new description")]
        [InlineData("abcd1234-1234-1234-1234-000000000501", "new description", null)]
        [InlineData("abc", "new description", null)]
        public async Task UpdateProductDescription_Test(string id, string description, string? newDescription)
        {
            var product = await module.UpdateProductDescriptionAsync(id, description);
            Assert.Equal(newDescription, product?.Description);
        }

        [Theory]
        [InlineData(1, 10, 10, 1, 10)]
        [InlineData(2, 10, 5, 2, 10)]
        [InlineData(3, 10, 0, 3, 10)]
        [InlineData(-1, 9, 9, 1, 9)]
        [InlineData(1, 0, 10, 1, 10)]
        public async Task GetProductsPaged_Test(int pageNumber, int pageSize, int productsCount, int responsePageSize, int responsePageNumber)
        {
            var footer = new Footer { PageNumber = pageNumber, PageSize = pageSize };
            var products = await module.GetProductsPagedAsync(footer);
            Assert.Equal(productsCount, products?.Products?.Count());
            Assert.Equal(responsePageNumber, products?.Footer?.PageSize);
            Assert.Equal(responsePageSize, products?.Footer?.PageNumber);
        }

    }
}
