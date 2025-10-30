using System;

namespace FullStackCI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        // Expone los repositorios
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }
        ICategoryRepository Category { get; }

        ICategoriaCommandRepository CommandRepository { get; }

        IAuthorCommandRepository AuthorCommandRepository { get; }

        IBookCommandRepository BookCommandRepository { get; }

        // Método para confirmar los cambios
        Task SaveChangesAsync();
    }
  
}
