using AutoMapper;
using CakeShop.Entites;
using CakeShop.Repositories;
using CakeShopService.Dtos;

namespace CakeShopService.Services.impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto?> CreateCategory(CategoryDto category)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(category);

                var createdCategory = await _categoryRepository.CreateCategory(categoryEntity);

                if (createdCategory == null)
                {
                    return null;
                }

                var categoryResponseDto = _mapper.Map<CategoryResponseDto>(createdCategory);

                return categoryResponseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating a category.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                var deleted = await _categoryRepository.DeleteCategory(categoryId);
                return deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while deleting a category.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();

                var categoryResponseDtos = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);

                return categoryResponseDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting all categories.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<CategoryResponseDto?> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);

                if (category == null)
                {
                    return null;
                }

                var categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);

                return categoryResponseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting a category by ID.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<CategoryResponseDto?> UpdateCategory(int categoryId, CategoryDto category)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(category);

                var updatedCategory = await _categoryRepository.UpdateCategory(categoryId, categoryEntity);

                if (updatedCategory == null)
                {
                    return null;
                }

                var categoryResponseDto = _mapper.Map<CategoryResponseDto>(updatedCategory);

                return categoryResponseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating a category.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }
    }
}
