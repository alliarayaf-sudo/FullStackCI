using FullStackCI.Dtos;

namespace FullStackCI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryDtov2?> GetCategoryByIdAsyncv2(int id);


    }
}
