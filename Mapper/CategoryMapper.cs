using AutoMapper;
using CakeShop.Entites;
using CakeShopService.Dtos;

namespace CakeShopService.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            // Map from Category to CategoryDto and vice versa
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Map from Category to CategoryResponseDto and vice versa
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CategoryResponseDto, Category>();
        }
    }
}
