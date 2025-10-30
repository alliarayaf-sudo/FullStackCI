using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    /// <summary>
    /// Clase servicio de autor
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _authorRepository;
        //private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthorService(IUnitOfWork authorRepository)
        {
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// obtener todos los autores
        /// </summary>
        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.Author.GetAllAsync();
            return authors.Select(ConvertToDto);
        }

        /// <summary>
        /// Obtener autor por id
        /// </summary>
        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.Author.GetByIdAsync(id);
            return author == null ? null : ConvertToDto(author);
        }

        /// <summary>
        /// Convetir DTO
        /// </summary>
        private AuthorDto ConvertToDto(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality,
                BirthYear = author.BirthYear
            };
        }
    }
}
