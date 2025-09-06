using Moq;
using MyCoach.API.Storage;
using MyCoach.DTOs;
using MyCoach.Services;
using System.Text.Json;

namespace MyCoach.Tests
{
    public class EquipmentServiceTests
    {
        private readonly EquipmentService _equipmentService;
        public EquipmentServiceTests()
        {
            // 1) Charger le JSON de test (copié dans le dossier de sortie)
            var path = Path.Combine(AppContext.BaseDirectory, "TestData", "equipments.json");
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<EquipmentDto>>(json) ?? new List<EquipmentDto>();

            // 2) Mock du IJsonStore
            var store = new Mock<IJsonStore>();

            // Le service appelle ReadAsync<List<EquipmentDto>> avec le nom de fichier "equipments.json"
            store.Setup(s => s.ReadAsync<List<EquipmentDto>>(
                    "equipments.json",
                    It.IsAny<CancellationToken>()))
                 .ReturnsAsync(data);

            // 3) Injecter le mock dans le service
            _equipmentService = new EquipmentService(store.Object);
        }

        [Fact]
        public async Task GetAllEquipments_ShouldReturnAllEquipments()
        {
            var equipments = await _equipmentService.GetAllAsync();
            Assert.NotNull(equipments);
            Assert.Equal(8, equipments.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetEquipmentById_ShouldReturnEquipment_WhenIdExists(int id)
        {
            var equipment = await _equipmentService.GetByIdAsync(id);
            Assert.NotNull(equipment);
            Assert.Equal(id, equipment?.Id);
        }

        [Fact]
        public async Task GetEquipmentById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Act
            var equipment = await _equipmentService.GetByIdAsync(999);

            // Assert
            Assert.Null(equipment);
        }
    }
}