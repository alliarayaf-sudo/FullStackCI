using FullStackCI.Dtos;

namespace FullStackCI.Services
{
    public interface IAuthorCommandService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task<AuthorDto?> UpdateAuthorAsync(int id, CreateAuthorDto updateAuthorDto);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
