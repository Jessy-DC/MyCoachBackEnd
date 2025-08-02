using MyCoach.DTOs;
using MyCoach.Interfaces;
using System.Text.Json;

namespace MyCoach.Services
{
    public class AdviceService : IAdviceService
    {
        private readonly string _jsonPath;

        public AdviceService(string jsonPath = null)
        {
            _jsonPath = jsonPath ?? Path.Combine(AppContext.BaseDirectory, "Data", "advices.json");
        }

        public IEnumerable<AdviceDto> GetAll()
        {
            var json = File.ReadAllText(_jsonPath);
            return JsonSerializer.Deserialize<List<AdviceDto>>(json) ?? new List<AdviceDto>();
        }


        public AdviceDto? GetById(int id) =>
            GetAll().FirstOrDefault(a => a.Id == id);
    }
}
