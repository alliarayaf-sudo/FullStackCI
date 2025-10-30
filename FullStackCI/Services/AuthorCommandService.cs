using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    /// <summary>
    /// Clase command service
    /// </summary>
    public class AuthorCommandService : IAuthorCommandService
    {
        private readonly IUnitOfWork _authorRepository;
        //private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthorCommandService(IUnitOfWork authorRepository)
        {
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// Crear autor
        /// </summary>
        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                Name = createAuthorDto.Name,
                Nationality = createAuthorDto.Nationality,
                BirthYear = createAuthorDto.BirthYear
            };

            var createdAuthor = await _authorRepository.AuthorCommandRepository.CreateAsync(author);
            await _authorRepository.SaveChangesAsync();
            return ConvertToDto(createdAuthor);
        }

        /// <summary>
        /// actualizar autor
        /// </summary>
        public async Task<AuthorDto?> UpdateAuthorAsync(int id, CreateAuthorDto updateAuthorDto)
        {
            var author = await _authorRepository.Author.GetByIdAsync(id);
            if (author == null) return null;

            author.Name = updateAuthorDto.Name;
            author.Nationality = updateAuthorDto.Nationality;
            author.BirthYear = updateAuthorDto.BirthYear;

            await _authorRepository.AuthorCommandRepository.UpdateAsync(author);
            await _authorRepository.SaveChangesAsync();
            return ConvertToDto(author);
        }

        /// <summary>
        /// eliminar autor
        /// </summary>
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            if (!await _authorRepository.Author.ExistsAsync(id))
                return false;

            await _authorRepository.AuthorCommandRepository.DeleteAsync(id);
            await _authorRepository.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Convertir DTO
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
