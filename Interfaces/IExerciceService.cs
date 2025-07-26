using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IExerciceService
    {
        IEnumerable<ExerciceDto> GetAllExercices();
        ExerciceDto? GetExerciceById(int id);
    }
}
