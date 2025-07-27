using MyCoach.DTOs;

namespace MyCoach.Interfaces
{
    public interface IAdviceService
    {
        IEnumerable<AdviceDto> GetAllAdvices();
        AdviceDto? GetAdviceById(int id);
    }
}
