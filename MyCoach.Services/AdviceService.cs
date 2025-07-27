using MyCoach.DTOs;
using MyCoach.Interfaces;

namespace MyCoach.Services
{
    public class AdviceService : IAdviceService
    {

        private readonly List<AdviceDto> _advices = new()
        {
            new AdviceDto
            {
                Id = 1,
                Title = "Stay Hydrated",
                Description = "Drink plenty of water throughout the day to stay hydrated.",
                Category = "Health"
            },
            new AdviceDto
            {
                Id = 2,
                Title = "Balanced Diet",
                Description = "Maintain a balanced diet with a variety of nutrients.",
                Category = "Nutrition"
            },
            new AdviceDto
            {
                Id = 3,
                Title = "Regular Exercise",
                Description = "Engage in regular physical activity to improve overall health.",
                Category = "Fitness"
            }
        };
        
        public IEnumerable<AdviceDto> GetAllAdvices() => _advices;

        public AdviceDto? GetAdviceById(int id) => _advices.FirstOrDefault(a => a.Id == id);
    }
}
