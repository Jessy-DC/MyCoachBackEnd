using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IExerciceService
    {
        Task<IEnumerable<ExerciceDto>> GetAllAsync(CancellationToken ct);
        Task<ExerciceDto?> GetByIdAsync(int id, CancellationToken ct);
    }
}
