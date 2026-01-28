using Microsoft.EntityFrameworkCore;
using RickMorty.Infrastructure.Persistence;
using RickMorty.Application.Interfaces;
using RickMorty.Infrastructure.Repositories;
using RickMorty.Application.External;
using RickMorty.Infrastructure.External;
using RickMorty.Api.Middleware;
using RickMorty.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Services
// =======================

// Controllers
builder.Services.AddControllers();

// Repositories
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

// Services
builder.Services.AddScoped<CharacterService>();

// HttpClient Rick & Morty
builder.Services.AddHttpClient<IRickMortyClient, RickMortyClient>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "RickMorty.Api",
        Version = "v1"
    });
});

// =======================
// Database
// =======================

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("Default");

    options.UseMySql(
        connection,
        ServerVersion.AutoDetect(connection)
    );
});

// =======================

var app = builder.Build();

// =======================
// Middleware
// =======================

// Global error handler
app.UseMiddleware<ErrorMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "RickMorty.Api v1"
        );
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
