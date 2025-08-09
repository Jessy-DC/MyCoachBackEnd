using MyCoach.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyCoach.DTOs;

namespace MyCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercicesController : ControllerBase
    {
        private readonly IExerciceService _exerciceService;

        public ExercicesController(IExerciceService exerciceService)
        {
            _exerciceService = exerciceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExerciceDto>>> GetAllExercices(CancellationToken ct)
        {
            var exercices = await _exerciceService.GetAllAsync(ct);

            if (exercices == null || !exercices.Any())
                return NotFound("No advices found.");

            return Ok(exercices);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ExerciceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdviceDto>> GetExerciceById(int id, CancellationToken ct)
        {
            var exercice = await _exerciceService.GetByIdAsync(id, ct);

            if (exercice is null)
                return NotFound($"Exercice with ID {id} not found.");

            return Ok(exercice);
        }
    }
}
