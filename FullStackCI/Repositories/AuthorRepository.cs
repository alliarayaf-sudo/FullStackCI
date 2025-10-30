using FullStackCI.Data;
using FullStackCI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Repositories
{
    /// <summary>
    /// Clase de repositorio de autor
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;


        /// <summary>
        /// Constructor
        /// </summary>
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener autores
        /// </summary>
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        /// <summary>
        /// Obtener autores por id
        /// </summary>
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }


        /// <summary>
        /// Comprobar si existe
        /// </summary>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
