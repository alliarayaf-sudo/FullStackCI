using FullStackCI.Dtos;

namespace FullStackCI.Services
{
    public interface IBookCommandService
    {
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
