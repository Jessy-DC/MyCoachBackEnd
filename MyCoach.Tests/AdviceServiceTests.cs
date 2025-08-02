using MyCoach.Interfaces;
using MyCoach.Services;

namespace MyCoach.Tests
{
    public class AdviceServiceTests
    {
        private readonly AdviceService _adviceService;
        public AdviceServiceTests()
        {
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "advices.json");
            _adviceService = new AdviceService(jsonPath);
        }

        [Fact]
        public void GetAllAdvices_ShouldReturnAllAdvices()
        {
            // Act
            var advices = _adviceService.GetAll();
            // Assert
            Assert.NotNull(advices);
            Assert.NotEmpty(advices);
            Assert.Equal(4, advices.Count());
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetAdviceById_ShouldReturnAdvice_WhenIdExists(int id)
        {
            // Act
            var advice = _adviceService.GetById(id);
            // Assert
            Assert.NotNull(advice);
            Assert.Equal(id, advice?.Id);
        }
        [Fact]
        public void GetAdviceById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var advice = _adviceService.GetById(999);
            // Assert
            Assert.Null(advice);
        }
    }
}
