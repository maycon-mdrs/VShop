using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.ProductApi.Controllers;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Services;

namespace Test
{
    public class CategoryControllerTest
    {
        private Mock<ICategoryService> _categoryServiceMock = null;

        public CategoryControllerTest()
        {
            if(_categoryServiceMock == null)
            {
                _categoryServiceMock = new Mock<ICategoryService>();
            }
        }

        [Fact]
        public async void GetTest()
        {
            // arrange
            var category = GetSampleCategory();
            _categoryServiceMock.Setup(x => x.GetCategories()).ReturnsAsync(GetSampleCategory);

            var controller = new CategoriesController(_categoryServiceMock.Object);

            // act
            var actionResult = await controller.Get();
            var result = actionResult.Result as OkObjectResult;
            var actual = result as IEnumerable<CategoryDTO>;


            // assert
            // Assert.IsType<IEnumerable<CategoryDTO>>(actual);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            // Assert.NotNull(actual);
            //Assert.Equal(GetSampleCategory().Count, actual.Count());

        }


        private List<CategoryDTO> GetSampleCategory()
        {
            CategoryDTO category = new CategoryDTO();
            category.Name = "Test";
            category.CategoryId = 15;

            return new List<CategoryDTO> { category };
        }
    }
}
