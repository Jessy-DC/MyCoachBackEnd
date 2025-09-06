using MyCoach.API.Storage;
using MyCoach.DTOs;
using MyCoach.Interfaces;

namespace MyCoach.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IJsonStore _store;
        private const string FileName = "equipments.json";
        public EquipmentService(IJsonStore store) => _store = store;

        public async Task<IEnumerable<EquipmentDto>> GetAllAsync(CancellationToken ct = default)
            => await _store.ReadAsync<List<EquipmentDto>>(FileName, ct) ?? new List<EquipmentDto>();

        public async Task<EquipmentDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var all = await GetAllAsync(ct);
            return all.FirstOrDefault(e => e.Id == id);
        }
    }
}