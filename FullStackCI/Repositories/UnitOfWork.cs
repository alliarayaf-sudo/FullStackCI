using FullStackCI.Data;
using System;

namespace FullStackCI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }
        public ICategoryRepository Category { get; private set; }

        public ICategoriaCommandRepository CommandRepository { get; private set; }

        public IAuthorCommandRepository AuthorCommandRepository { get; private set; }

        public IBookCommandRepository BookCommandRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            // Inicializar repositorios
            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
            Category = new CategoryRepository(_context);
            CommandRepository = new CategoriaCommandRepository(_context);
            AuthorCommandRepository = new AuthorCommandRepository(_context);

        }

        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
