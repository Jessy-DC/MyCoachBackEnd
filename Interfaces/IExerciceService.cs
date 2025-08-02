using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IExerciceService
    {
        IEnumerable<ExerciceDto> GetAll();
        ExerciceDto? GetById(int id);
    }
}
