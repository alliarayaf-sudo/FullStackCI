using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;
using FullStackCI.Data;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _bookRepository;
        private readonly ApplicationDbContext _context;

        public BookService(IUnitOfWork bookRepository, ApplicationDbContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.Book.GetAllAsync();
            return books.Select(ConvertToDto);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.Book.GetByIdAsync(id);
            return book == null ? null : ConvertToDto(book);
        }



        private BookDto ConvertToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                Pages = book.Pages,
                Description = book.Description,
                CategoryId = book.CategoryId,
                CategoryName = book.Category?.Name ?? string.Empty,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name ?? string.Empty
            };
        }
    }
}
