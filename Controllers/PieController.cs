using System.Text.Json;
using CakeShopService.Dtos;
using CakeShopService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieController : ControllerBase
    {
        private readonly IPieService _pieService;

        public PieController(IPieService pieService)
        {
            _pieService = pieService;
        }

        [HttpGet("{pieId}")]
        public async Task<ActionResult<PieResponseDto>> GetPieAsync(int pieId)
        {
            var pie = await _pieService.GetPieAsync(pieId);
            if (pie == null)
            {
                return NotFound();
            }
            return Ok(pie);
        }

        [HttpPost]
        public async Task<ActionResult<PieResponseDto>> CreatePieAsync([FromBody] PieDto pieDto)
        {
            var createdPie = await _pieService.CreatePieAsync(pieDto);
            if (createdPie == null)
            {
                return BadRequest();
            }
            // Construct the URI for the newly created pie
            var uri = Url.Action(nameof(GetPieAsync), new { pieId = createdPie.PieId });

            // Return a 201 Created response with the URI and the created pie object
            return Created(uri, createdPie);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieResponseDto>>> GetPiesAsync()
        {
            var pies = await _pieService.GetPiesAsync();
            return Ok(pies);
        }

        [HttpGet("piesOfTheWeek")]
        public async Task<ActionResult<IEnumerable<PieResponseDto>>> GetPiesOfTheWeekAsync()
        {
            var pies = await _pieService.GetPiesOfTheWeekAsync();
            return Ok(pies);
        }

        [HttpPut("{pieId}")]
        public async Task<ActionResult<PieResponseDto>> UpdatePieAsync(int pieId, [FromBody] PieDto pieDto)
        {
            var updatedPie = await _pieService.UpdatePieAsync(pieId, pieDto);
            if (updatedPie == null)
            {
                return NotFound();
            }
            return Ok(updatedPie);
        }

        [HttpDelete("{pieId}")]
        public async Task<ActionResult> DeletePieAsync(int pieId)
        {
            var result = await _pieService.DeletePieAsync(pieId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
