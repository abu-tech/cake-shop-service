using CakeShop.Entites;

namespace CakeShop.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateCategory(Category category);
        Task<Category?> UpdateCategory(int categoryId, Category category);
        Task<Category?> GetCategoryById(int categoryId);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<bool> DeleteCategory(int categoryId);
    }
}
