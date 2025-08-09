using Moq;
using MyCoach.API.Storage;
using MyCoach.DTOs;
using MyCoach.Services;
using System.Text.Json;

namespace MyCoach.Tests
{
    public class ExerciceServiceTests
    {
        private readonly ExerciceService _exerciceService;

        public ExerciceServiceTests()
        {
            // 1) Charger le JSON de test (copié dans le dossier de sortie)
            var path = Path.Combine(AppContext.BaseDirectory, "TestData", "exercices.json");
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<ExerciceDto>>(json) ?? new List<ExerciceDto>();

            // 2) Mock du IJsonStore
            var store = new Mock<IJsonStore>();

            // Le service appelle ReadAsync<List<AdviceDto>> avec le nom de fichier "advices.json"
            store.Setup(s => s.ReadAsync<List<ExerciceDto>>(
                    "exercices.json",
                    It.IsAny<CancellationToken>()))
                 .ReturnsAsync(data);

            // 3) Injecter le mock dans le service
            _exerciceService = new ExerciceService(store.Object);
        }

        [Fact]
        public async Task GetAllExercices_ShouldReturnAllExercices()
        {
            var exercices = await _exerciceService.GetAllAsync();
            Assert.NotNull(exercices);
            Assert.Equal(4, exercices.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetExerciceById_ShouldReturnExercice_WhenIdExists(int id)
        {
            var exercice = await _exerciceService.GetByIdAsync(id);
            Assert.NotNull(exercice);
            Assert.Equal(id, exercice?.Id);
        }

        [Fact]
        public async Task GetExerciceById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var exercice = await _exerciceService.GetByIdAsync(999);

            // Assert
            Assert.Null(exercice);
        }
    }
}