using MovieRaptor.Application;
using MovieRaptor.Domain.Movies;
using MovieRaptor.Infrastructure;
using MovieRaptor.Infrastructure.Movies.Movie;
using TMDbLib.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("apikeys.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
builder.Services.AddAutoMapper(typeof(ApplicationAssemblyReference).Assembly, typeof(InfrastructureAssemblyReference).Assembly);
builder.Services.AddSingleton(client => new TMDbClient(builder.Configuration["TMDbApiKey"]));
builder.Services.AddSingleton<IMovieRepository, TMDbMovieRepository>();

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
