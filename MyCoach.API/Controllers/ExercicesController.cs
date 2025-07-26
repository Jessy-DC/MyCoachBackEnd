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
        public ActionResult<IEnumerable<ExerciceDto>> GetAllExercices()
        {
            var exercices = _exerciceService.GetAllExercices();

            return Ok(exercices);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ExerciceDto> GetExerciceById(int id)
        {
            var exercice = _exerciceService.GetExerciceById(id);

            if (exercice == null)
            {
                return NotFound();
            }

            return Ok(exercice);
        }
    }
}
