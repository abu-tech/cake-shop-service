using CakeShop.Entites;
using CakeShopService.Entites;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Repositories.impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category?> GetCategoryById(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if(category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> UpdateCategory(int categoryId, Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(categoryId);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;

            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}
