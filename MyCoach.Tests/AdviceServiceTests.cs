using Moq;
using MyCoach.API.Storage;
using MyCoach.DTOs;
using MyCoach.Services;
using System.Text.Json;

namespace MyCoach.Tests
{
    public class AdviceServiceTests
    {
        private readonly AdviceService _adviceService;
        public AdviceServiceTests()
        {
            // 1) Charger le JSON de test (copié dans le dossier de sortie)
            var path = Path.Combine(AppContext.BaseDirectory, "TestData", "advices.json");
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<AdviceDto>>(json) ?? new List<AdviceDto>();

            // 2) Mock du IJsonStore
            var store = new Mock<IJsonStore>();

            // Le service appelle ReadAsync<List<AdviceDto>> avec le nom de fichier "advices.json"
            store.Setup(s => s.ReadAsync<List<AdviceDto>>(
                    "advices.json",
                    It.IsAny<CancellationToken>()))
                 .ReturnsAsync(data);

            // 3) Injecter le mock dans le service
            _adviceService = new AdviceService(store.Object);
        }

        [Fact]
        public async Task GetAllAdvices_ShouldReturnAllAdvices()
        {
            var advices = await _adviceService.GetAllAsync();
            Assert.NotNull(advices);
            Assert.Equal(4, advices.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetAdviceById_ShouldReturnAdvice_WhenIdExists(int id)
        {
            var advice = await _adviceService.GetByIdAsync(id);
            Assert.NotNull(advice);
            Assert.Equal(id, advice?.Id);
        }

        [Fact]
        public async Task GetAdviceById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var advice = await _adviceService.GetByIdAsync(999);

            // Assert
            Assert.Null(advice);
        }
    }
}
