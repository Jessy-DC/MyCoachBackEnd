using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IAdviceService
    {
        Task<IEnumerable<AdviceDto>> GetAllAsync(CancellationToken ct);
        Task<AdviceDto?> GetByIdAsync(int id, CancellationToken ct);
    }
}
