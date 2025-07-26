using MyCoach.Services;

namespace MyCoach.Tests
{
    public class ExerciceServiceTests
    {
        private readonly ExerciceService _exerciceService;

        public ExerciceServiceTests()
        {
            _exerciceService = new ExerciceService();
        }

        [Fact]
        public void GetAllExercices_ShouldReturnAllExercices()
        {
            // Act
            var exercices = _exerciceService.GetAllExercices();
            // Assert
            Assert.NotNull(exercices);
            Assert.NotEmpty(exercices);
            Assert.Equal(3, exercices.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetExerciceById_ShouldReturnExercice_WhenIdExists(int id)
        {
            // Act
            var exercice = _exerciceService.GetExerciceById(id);
            // Assert
            Assert.NotNull(exercice);
            Assert.Equal(id, exercice?.Id);
        }

        [Fact]
        public void GetExerciceById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var exercice = _exerciceService.GetExerciceById(999);
            // Assert
            Assert.Null(exercice);
        }
    }
}