using MyCoach.API.Storage;
using MyCoach.Interfaces; // Ensure this using directive is present
using MyCoach.Services;   // Ensure this using directive is present

var builder = WebApplication.CreateBuilder(args);

var jsonPath = Environment.GetEnvironmentVariable("JSON_DATA_PATH");
if (string.IsNullOrWhiteSpace(jsonPath))
{
    jsonPath = Path.Combine(AppContext.BaseDirectory, "Data");
}
Directory.CreateDirectory(jsonPath);

// 2) Enregistrement du store concret
builder.Services.AddSingleton(new JsonStorageOptions { RootPath = jsonPath });
builder.Services.AddSingleton<IJsonStore, FileJsonStore>();

// Add services to the container.
builder.Services.AddScoped<IExerciceService, ExerciceService>(); // Ensure ExerciceService implements IExerciceService
builder.Services.AddScoped<IAdviceService, AdviceService>(); // Ensure ExerciceService implements IExerciceService
builder.Services.AddScoped<IEquipmentService, EquipmentService>(); // Add EquipmentService
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/health", () => Results.Ok("OK"));

app.MapControllers();

app.Run();
