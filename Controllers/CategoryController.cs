using CakeShopService.Dtos;
using CakeShopService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CakeShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponseDto>> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var createdCategory = await _categoryService.CreateCategory(categoryDto);
            if (createdCategory == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createdCategory.CategoryId }, createdCategory);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(int categoryId, [FromBody] CategoryDto categoryDto)
        {
            var updatedCategory = await _categoryService.UpdateCategory(categoryId, categoryDto);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return updatedCategory;
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var result = await _categoryService.DeleteCategory(categoryId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
