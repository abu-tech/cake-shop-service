using CakeShopService.Dtos;

namespace CakeShopService.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto?> CreateCategory(CategoryDto category);
        Task<CategoryResponseDto?> UpdateCategory(int categoryId, CategoryDto category);
        Task<CategoryResponseDto?> GetCategoryById(int categoryId);
        Task<IEnumerable<CategoryResponseDto>> GetAllCategories();
        Task<bool> DeleteCategory(int categoryId);
    }
}
