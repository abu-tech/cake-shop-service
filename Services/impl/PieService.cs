using AutoMapper;
using CakeShop.Entites;
using CakeShop.Repositories;
using CakeShopService.Dtos;

namespace CakeShopService.Services.impl
{
    public class PieService : IPieService
    {
        private readonly IPieRepository _pieRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PieService> _logger;

        public PieService(IPieRepository pieRepository, IMapper mapper, ILogger<PieService> logger)
        {
            _pieRepository = pieRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PieResponseDto> CreatePieAsync(PieDto pieDto)
        {
            try
            {
                var pie = _mapper.Map<Pie>(pieDto);
                var addedPie = await _pieRepository.CreatePie(pie);
                var addedPieDto = _mapper.Map<PieResponseDto>(addedPie);
                return addedPieDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while adding a pie.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<IEnumerable<PieResponseDto>> GetPiesOfTheWeekAsync()
        {
            try
            {
                var pies = await _pieRepository.PiesOfTheWeek();
                var pieDtos = _mapper.Map<IEnumerable<PieResponseDto>>(pies);
                return pieDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting pies of the week.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<bool> DeletePieAsync(int pieId)
        {
            try
            {
                return await _pieRepository.DeletePie(pieId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while deleting a pie.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<PieResponseDto?> GetPieAsync(int pieId)
        {
            try
            {
                var pie = await _pieRepository.GetPieById(pieId);
                var pieDto = _mapper.Map<PieResponseDto>(pie);
                return pieDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getiing a pie.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<IEnumerable<PieResponseDto>> GetPiesAsync()
        {
            try
            {
                var pies = await _pieRepository.GetAllpies();
                var pieDtos = _mapper.Map<IEnumerable<PieResponseDto>>(pies);
                return pieDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while getting all pies.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task<PieResponseDto?> UpdatePieAsync(int pieId, PieDto pieDto)
        {
            try
            {
                var pie = _mapper.Map<Pie>(pieDto);
                var updatedPie = await _pieRepository.UpdatePie(pieId, pie);
                var updatedPieDto = _mapper.Map<PieResponseDto>(updatedPie);
                return updatedPieDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while updating a pie.");
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }
    }
}
