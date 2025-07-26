using MyCoach.Interfaces;
using MyCoach.DTOs;
namespace MyCoach.Services
{
    public class ExerciceService : IExerciceService
    {
        private readonly List<ExerciceDto> _exercices = new()
        {
            new ExerciceDto {
                Id = 1,
                Title = "Push-Up",
                Description = "A basic exercise to strengthen the upper body.",
                VideoUrl = "https://example.com/pushup-video",
                ImageUrl = "https://example.com/pushup-image.jpg",
                Category = "Strength",
                Duration = 5,
                Difficulty = "Easy",
                Equipment = "None",
                TargetMuscleGroup = "Chest"
            },
            new ExerciceDto {
                Id = 2,
                Title = "Squat",
                Description = "A fundamental exercise for lower body strength.",
                VideoUrl = "https://example.com/squat-video",
                ImageUrl = "https://example.com/squat-image.jpg",
                Category = "Strength",
                Duration = 10,
                Difficulty = "Medium",
                Equipment = "None",
                TargetMuscleGroup = "Legs"
            },
            new ExerciceDto {
                Id = 3,
                Title = "Plank",
                Description = "An isometric exercise to strengthen the core.",
                VideoUrl = "https://example.com/plank-video",
                ImageUrl = "https://example.com/plank-image.jpg",
                Category = "Core",
                Duration = 2,
                Difficulty = "Easy",
                Equipment = "None",
                TargetMuscleGroup = "Core"
            }
        };
        public IEnumerable<ExerciceDto> GetAllExercices() => _exercices;

        public ExerciceDto? GetExerciceById(int id) => _exercices.FirstOrDefault(e => e.Id == id);
    }
}
