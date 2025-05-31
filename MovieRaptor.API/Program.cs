using MovieRaptor.Application;
using MovieRaptor.Domain.Interfaces;
using MovieRaptor.Infrastructure;
using TMDbLib.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("apikeys.json");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplicationDependencies();
builder.Services.AddSingleton<IMovieRepository>(repo => new TMDbMovieRepository(new TMDbClient("")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
