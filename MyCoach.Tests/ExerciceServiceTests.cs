using MyCoach.Services;

namespace MyCoach.Tests
{
    public class ExerciceServiceTests
    {
        private readonly ExerciceService _exerciceService;

        public ExerciceServiceTests()
        {
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "exercices.json");
            _exerciceService = new ExerciceService(jsonPath);
        }

        [Fact]
        public void GetAllExercices_ShouldReturnAllExercices()
        {
            // Act
            var exercices = _exerciceService.GetAll();
            // Assert
            Assert.NotNull(exercices);
            Assert.NotEmpty(exercices);
            Assert.Equal(4, exercices.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetExerciceById_ShouldReturnExercice_WhenIdExists(int id)
        {
            // Act
            var exercice = _exerciceService.GetById(id);
            // Assert
            Assert.NotNull(exercice);
            Assert.Equal(id, exercice?.Id);
        }

        [Fact]
        public void GetExerciceById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var exercice = _exerciceService.GetById(999);
            // Assert
            Assert.Null(exercice);
        }
    }
}