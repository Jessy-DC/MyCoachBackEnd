using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetAllAsync(CancellationToken ct);
        Task<EquipmentDto?> GetByIdAsync(int id, CancellationToken ct);
    }
}