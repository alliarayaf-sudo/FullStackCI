using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    public class CategoriaCommandService : ICategoriaCommandService
    {
        private readonly IUnitOfWork _categoryRepository;


    public CategoriaCommandService(IUnitOfWork categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description
            };

            var createdCategory = await _categoryRepository.CommandRepository.CreateAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return ConvertToDto(createdCategory);
        }

        public async Task<CategoryDto?> UpdateCategoryAsync(int id, CreateCategoryDto updateCategoryDto)
        {
            var category = await _categoryRepository.Category.GetByIdAsync(id);
            if (category == null) return null;

            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;

            await _categoryRepository.CommandRepository.UpdateAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return ConvertToDto(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            if (!await _categoryRepository.Category.ExistsAsync(id))
                return false;

            await _categoryRepository.CommandRepository.DeleteAsync(id);
            await _categoryRepository.SaveChangesAsync();
            return true;
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
    }
}
