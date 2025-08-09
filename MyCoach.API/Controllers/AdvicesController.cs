using Microsoft.AspNetCore.Mvc;
using MyCoach.DTOs;
using MyCoach.Interfaces;

namespace MyCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvicesController : ControllerBase
    {
        private readonly IAdviceService _adviceService;

        public AdvicesController(IAdviceService adviceService)
        {
            _adviceService = adviceService;
        }

        // GET: api/advices
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AdviceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AdviceDto>>> GetAllAdvices(CancellationToken ct)
        {
            var advices = await _adviceService.GetAllAsync(ct);

            if (advices == null || !advices.Any())
                return NotFound("No advices found.");

            return Ok(advices);
        }

        // GET: api/advices/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AdviceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdviceDto>> GetAdviceById(int id, CancellationToken ct)
        {
            var advice = await _adviceService.GetByIdAsync(id, ct);
            if (advice is null)
                return NotFound($"Advice with ID {id} not found.");

            return Ok(advice);
        }
    }
}