using FullStackCI.Data;
using FullStackCI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Repositories
{
    /// <summary>
    /// Clase de command de autor
    /// </summary>
    public class AuthorCommandRepository : IAuthorCommandRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthorCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crear autor
        /// </summary>
        public async Task<Author> CreateAsync(Author Author)
        {
            _context.Authors.Add(Author);
            // await _context.SaveChangesAsync();
            return Author;
        }

        /// <summary>
        /// Actualizar autor
        /// </summary>
        public async Task UpdateAsync(Author Author)
        {
            _context.Entry(Author).State = EntityState.Modified;
            // await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Eliminar autor
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var Author = await _context.Categories.FindAsync(id);
            if (Author != null)
            {
                _context.Categories.Remove(Author);
                //  await _context.SaveChangesAsync();
            }
        }
    }
}
