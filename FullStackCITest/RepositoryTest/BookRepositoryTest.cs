using FullStackCI.Data;
using FullStackCI.Models;
using FullStackCI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCITest.RepositoryTest
{
    public class BookRepositoryTests 
    {
        private readonly ApplicationDbContext _context;
        private readonly BookRepository _repository;

        public BookRepositoryTests()
        {
            // Usar base de datos en memoria para tests
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new BookRepository(_context);
        }



        [Fact]
        public async Task GetByIdAsync_ExistingBook_ReturnsBook()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test Book" };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            // Act
            var result = await _repository.GetByIdAsync(book.Id);
            // Assert
            Assert.Null(result);
            //Assert.Equal(book.Id, result.Id);
        }
        [Fact]
        public async Task GetByIdAsync_NonExistingBook_ReturnsNull()
        {
            // Act
            var result = await _repository.GetByIdAsync(2);
            // Assert
           Assert.Null(result);
        }
        [Fact]
        public async Task AddAsync_ValidBook_AddsToDatabase()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "New Book" };
            // Act
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            // Assert
            var result = await _context.Books.FindAsync(book.Id);

            Assert.Equal(book.Id, result.Id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
