using Asp.Versioning;
using FullStackCI.Dtos;
using FullStackCI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStackCI.Controllers
{
    [ApiController]
    [Route("api/Categorias")]
    [ApiVersion("2")]
    public class Categoriesv2Controller : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        private readonly ICategoriaCommandService _categoriaCommandService;

        public Categoriesv2Controller(ICategoryService categoryService, ICategoriaCommandService categoriaCommandService)
        {
            _categoryService = categoryService;
            _categoriaCommandService = categoriaCommandService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDtov2>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsyncv2(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

    }
}
