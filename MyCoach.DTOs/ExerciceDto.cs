namespace MyCoach.DTOs
{
    public class ExerciceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Duration { get; set; } // Duration in minutes
        public string Difficulty { get; set; } = string.Empty;
        public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();
        public string TargetMuscleGroup { get; set; } = string.Empty;
    }
}
