using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IAdviceService
    {
        IEnumerable<AdviceDto> GetAll();
        AdviceDto? GetById(int id);
    }
}
