using Asp.Versioning;
using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FullStackCI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly LinkGenerator _linkGenerator; //LinkDTO
        private readonly IAuthorCommandService _authorCommandService;

        //Injeccion de dependencias en los constructores
        public AuthorsController(IAuthorService authorService, LinkGenerator linkGenerator, IAuthorCommandService authorCommand)
        {
            _authorService = authorService;
            _linkGenerator = linkGenerator;
            _authorCommandService = authorCommand;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            //var authors = await _authorService.GetAllAuthorsAsync();
            //return Ok(authors);
            var authors = await _authorService.GetAllAuthorsAsync();
            var resources = authors.Select(a => CreateAuthorResource(a)).ToList();
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = await _authorCommandService.CreateAuthorAsync(createAuthorDto);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, CreateAuthorDto updateAuthorDto)
        {
            var author = await _authorCommandService.UpdateAuthorAsync(id, updateAuthorDto);
            if (author == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorCommandService.DeleteAuthorAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        

        //HateOAS
        private Resource<AuthorDto> CreateAuthorResource(AuthorDto author)
        {
            var resource = new Resource<AuthorDto>(author);

            resource.Links.Add(new LinkDto
            {
                Rel = "self",
                Href = _linkGenerator.GetPathByAction(HttpContext, nameof(GetAuthor), values: new { id = author.Id }),
                Method = "GET"
            });

            resource.Links.Add(new LinkDto
            {
                Rel = "update",
                Href = _linkGenerator.GetPathByAction(HttpContext, nameof(UpdateAuthor), values: new { id = author.Id }),
                Method = "PUT"
            });

            resource.Links.Add(new LinkDto
            {
                Rel = "delete",
                Href = _linkGenerator.GetPathByAction(HttpContext, nameof(DeleteAuthor), values: new { id = author.Id }),
                Method = "DELETE"
            });

            resource.Links.Add(new LinkDto
            {
                Rel = "all-authors",
                Href = _linkGenerator.GetPathByAction(HttpContext, nameof(GetAuthors), values: null),
                Method = "GET"
            });

            return resource;
        }
    }
}


