using MyCoach.DTOs;
using MyCoach.Interfaces;
using System.Text.Json;
namespace MyCoach.Services
{
    public class ExerciceService : IExerciceService
    {
        private readonly string _jsonPath;

        public ExerciceService(string jsonPath = null)
        {
            _jsonPath = jsonPath ?? Path.Combine(AppContext.BaseDirectory, "Data", "exercices.json");
        }

        public IEnumerable<ExerciceDto> GetAll()
        {
            var json = File.ReadAllText(_jsonPath);
            return JsonSerializer.Deserialize<List<ExerciceDto>>(json) ?? new List<ExerciceDto>();
        }

        public ExerciceDto? GetById(int id) => GetAll().FirstOrDefault(e => e.Id == id);
    }
}
