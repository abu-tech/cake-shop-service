using CakeShopService.Dtos;

namespace CakeShopService.Services
{
    public interface IPieService
    {
        Task<IEnumerable<PieResponseDto>> GetPiesAsync();
        Task<IEnumerable<PieResponseDto>> GetPiesOfTheWeekAsync();
        Task<PieResponseDto?> GetPieAsync(int pieId);
        Task<PieResponseDto> CreatePieAsync(PieDto pieDto);
        Task<PieResponseDto?> UpdatePieAsync(int pieId, PieDto pieDto);
        Task<bool> DeletePieAsync(int pieId);
    }
}
