using Microsoft.AspNetCore.Mvc;
using MyCoach.DTOs;
using MyCoach.Interfaces;

namespace MyCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // GET: api/equipments
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EquipmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetAllEquipments(CancellationToken ct)
        {
            var equipments = await _equipmentService.GetAllAsync(ct);

            if (equipments == null || !equipments.Any())
                return NotFound("No equipments found.");

            return Ok(equipments);
        }

        // GET: api/equipments/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EquipmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EquipmentDto>> GetEquipmentById(int id, CancellationToken ct)
        {
            var equipment = await _equipmentService.GetByIdAsync(id, ct);
            if (equipment is null)
                return NotFound($"Equipment with ID {id} not found.");

            return Ok(equipment);
        }
    }
}