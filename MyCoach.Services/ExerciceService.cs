using MyCoach.API.Storage;
using MyCoach.DTOs;
using MyCoach.Interfaces;

namespace MyCoach.Services
{
    public class ExerciceService : IExerciceService
    {
        private readonly IJsonStore _store;
        private const string FileName = "exercices.json";
        public ExerciceService(IJsonStore store) => _store = store;

        public async Task<IEnumerable<ExerciceDto>> GetAllAsync(CancellationToken ct = default)
            => await _store.ReadAsync<List<ExerciceDto>>(FileName, ct) ?? new List<ExerciceDto>();

        public async Task<ExerciceDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var all = await GetAllAsync(ct);
            return all.FirstOrDefault(a => a.Id == id);
        }
    }
}