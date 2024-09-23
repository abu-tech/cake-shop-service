using AutoMapper;
using CakeShop.Entites;
using CakeShopService.Dtos;

namespace CakeShopService.Mapper
{
    public class PieMapper : Profile
    {
        public PieMapper()
        {
            // Map from Pie to PieDto and vice versa
            CreateMap<Pie, PieDto>();
            CreateMap<PieDto, Pie>();

            //Mapcfrom pie to PieResponseDto and vice versa
            CreateMap<Pie, PieResponseDto>();
            CreateMap<PieResponseDto, Pie>();
        }
    }
}
