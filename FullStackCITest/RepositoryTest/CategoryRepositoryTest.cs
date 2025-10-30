using FullStackCI.Models;
using FullStackCI.Repositories;
using FullStackCI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCITest.RepositoryTest
{
    public class CategoryServiceTest
    {
        //private readonly Mock<ICategoryRepository> _categoryRepository = new Mock<ICategoryRepository>();
        //private readonly Mock<ICategoryCommandRepository> _categoryCommandRepository = new Mock<ICategoryCommandRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly CategoryService _service;

        public CategoryServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _service = new CategoryService(_unitOfWork.Object);
        }

        [Fact]
        public void GetAllCategoria_Succes_ReturnCategoriaDto()
        {
            // Arrange
            var categorias = new List<Category>
            {
                new Category { Id = 1, Name = "Categoria1", Description = "Descripcion1" },
                new Category { Id = 2, Name = "Categoria2", Description = "Descripcion2" }
            };
            _unitOfWork.Setup(u => u.Category.GetAllAsync())
                .ReturnsAsync(categorias);
            // Act
            var result = _service.GetAllCategoriesAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Result.Count());
            Assert.Equal("Categoria1", result.Result.First().Name);
        }

        [Fact]
        public void GetByIdCategoria_ExistingId_ReturnCategoriaDto()
        {
            // Arrange
            var categoria = new Category { Id = 1, Name = "Categoria1", Description = "Descripcion1" };

            _unitOfWork.Setup(u => u.Category.GetByIdAsync(1))
                .ReturnsAsync(categoria);
            // Act
            var result = _service.GetCategoryByIdAsync(1);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Categoria1", result.Result.Name);
        }

        [Fact]
        public void GetExistsAsync_ExistingId_ReturnCategoriaDto()
        {
            _unitOfWork.Setup(u => u.Category.ExistsAsync(1))
                .ReturnsAsync(true); // Fix: Return a Task<bool> instead of a Category object.

            // Act
            var result = _service.GetCategoryExistsAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Result);
            Assert.Equal(true, result.Result);
        }

        [Fact]
        public void GetNotExistsAsync_ExistingId_ReturnCategoriaDto()
        {

            _unitOfWork.Setup(u => u.Category.ExistsAsync(3))
                .ReturnsAsync(false); // Fix: Return a Task<bool> instead of a Category object.
            // Act
            var result = _service.GetCategoryExistsAsync(3);
            // Assert
            Assert.NotNull(result);
            Assert.False(result.Result);
            Assert.Equal(false, result.Result);
        }

    }
}
