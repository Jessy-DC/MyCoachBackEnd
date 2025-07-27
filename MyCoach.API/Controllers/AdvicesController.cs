using Microsoft.AspNetCore.Mvc;
using MyCoach.DTOs;
using MyCoach.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCoach.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvicesController : ControllerBase
    {
        private readonly IAdviceService _adviceService;
        // GET: api/<AdvicesController>
        
        public AdvicesController(IAdviceService adviceService)
        {
            _adviceService = adviceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdviceDto>> GetAllAdvices()
        {
            var advices = _adviceService.GetAllAdvices();

            if (advices == null || !advices.Any())
            {
                return NotFound("No advices found.");
            }

            return Ok(advices);
        }

        // GET api/<AdvicesController>/5
        [HttpGet("{id:int}")]
        public ActionResult<AdviceDto> GetAdviceById(int id)
        {
            var advice = _adviceService.GetAdviceById(id);

            if (advice == null)
            {
                return NotFound($"Advice with ID {id} not found.");
            }

            return Ok(advice);
        }
    }
}
