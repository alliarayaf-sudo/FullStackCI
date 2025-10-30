using FullStackCI.Data;
using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Services
{
    public class BookCommandService : IBookCommandService
    {
        private readonly IUnitOfWork _bookRepository;
        private readonly ApplicationDbContext _context;

        public BookCommandService(IUnitOfWork bookRepository, ApplicationDbContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            // Verificar que el autor existe
            var authorExists = await _context.Authors.AnyAsync(a => a.Id == createBookDto.AuthorId);
            if (!authorExists)
            {
                throw new ArgumentException("El autor especificado no existe");
            }

            // Verificar que la categoría existe
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == createBookDto.CategoryId);
            if (!categoryExists)
            {
                throw new ArgumentException("La categoría especificada no existe");
            }

            var book = new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                PublicationYear = createBookDto.PublicationYear,
                Pages = createBookDto.Pages,
                Description = createBookDto.Description,
                CategoryId = createBookDto.CategoryId,
                AuthorId = createBookDto.AuthorId
            };

            var createdBook = await _bookRepository.BookCommandRepository.CreateAsync(book);
            await _bookRepository.SaveChangesAsync();
            return ConvertToDto(createdBook);
        }

        public async Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var book = await _bookRepository.Book.GetByIdAsync(id);
            if (book == null) return null;

            // Verificar que el autor existe
            var authorExists = await _context.Authors.AnyAsync(a => a.Id == updateBookDto.AuthorId);
            if (!authorExists)
            {
                throw new ArgumentException("El autor especificado no existe");
            }

            // Verificar que la categoría existe
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == updateBookDto.CategoryId);
            if (!categoryExists)
            {
                throw new ArgumentException("La categoría especificada no existe");
            }

            book.Title = updateBookDto.Title;
            book.ISBN = updateBookDto.ISBN;
            book.PublicationYear = updateBookDto.PublicationYear;
            book.Pages = updateBookDto.Pages;
            book.Description = updateBookDto.Description;
            book.CategoryId = updateBookDto.CategoryId;
            book.AuthorId = updateBookDto.AuthorId;

            await _bookRepository.BookCommandRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();
            return ConvertToDto(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            if (!await _bookRepository.Book.ExistsAsync(id))
                return false;

            await _bookRepository.BookCommandRepository.DeleteAsync(id);
            await _bookRepository.SaveChangesAsync();
            return true;
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
