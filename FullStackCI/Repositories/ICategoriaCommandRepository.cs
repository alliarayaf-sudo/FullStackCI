using FullStackCI.Models;

namespace FullStackCI.Repositories
{
    public interface ICategoriaCommandRepository
    {
        Task<Category> CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
