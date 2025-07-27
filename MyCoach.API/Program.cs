using MyCoach.Interfaces; // Ensure this using directive is present
using MyCoach.Services;   // Ensure this using directive is present

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IExerciceService, ExerciceService>(); // Ensure ExerciceService implements IExerciceService
builder.Services.AddScoped<IAdviceService, AdviceService>(); // Ensure ExerciceService implements IExerciceService
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

app.MapControllers();

app.Run();
