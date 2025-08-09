using MyCoach.API.Storage;
using MyCoach.DTOs;
using MyCoach.Interfaces;

namespace MyCoach.Services
{
    public class AdviceService : IAdviceService
    {
        private readonly IJsonStore _store;
        private const string FileName = "advices.json";
        public AdviceService(IJsonStore store) => _store = store;

        public async Task<IEnumerable<AdviceDto>> GetAllAsync(CancellationToken ct = default)
            => await _store.ReadAsync<List<AdviceDto>>(FileName, ct) ?? new List<AdviceDto>();

        public async Task<AdviceDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var all = await GetAllAsync(ct);
            return all.FirstOrDefault(a => a.Id == id);
        }
    }
}