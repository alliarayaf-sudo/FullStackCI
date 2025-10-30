using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _categoryRepository;


        public CategoryService(IUnitOfWork categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.Category.GetAllAsync();
            return categories.Select(ConvertToDto);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.Category.GetByIdAsync(id);
            return category == null ? null : ConvertToDto(category);
        }

        public async Task<CategoryDtov2?> GetCategoryByIdAsyncv2(int id)
        {
            var category = await _categoryRepository.Category.GetByIdAsync(id);
            return category == null ? null : ConvertToDtov2(category);
        }

        public async Task<bool> GetCategoryExistsAsync(int id)
        {
            var category = await _categoryRepository.Category.ExistsAsync(id);
            return category;
        }


        private CategoryDto ConvertToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        private CategoryDtov2 ConvertToDtov2(Category category)
        {
            return new CategoryDtov2
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Mensaje = "Prueba v2"
            };
        }
    }
}
