using Microsoft.EntityFrameworkCore;
using MovieRaptor.Application;
using MovieRaptor.Domain.Movies;
using MovieRaptor.Domain.Users;
using MovieRaptor.Infrastructure;
using MovieRaptor.Infrastructure.Movies.Movie;
using MovieRaptor.Infrastructure.Users;
using MovieRaptor.Infrastructure.Users.User;
using TMDbLib.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("apikeys.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
builder.Services.AddAutoMapper(cfg => { cfg.LicenseKey = ""; }, typeof(ApplicationAssemblyReference).Assembly, typeof(InfrastructureAssemblyReference).Assembly);
builder.Services.AddScoped(client => new TMDbClient(builder.Configuration["TMDbApiKey"]));
builder.Services.AddScoped<IMovieRepository, TMDbMovieRepository>();
builder.Services.AddScoped<IUserRepository, PostgreSqlUserRepository>();

builder.Services.AddDbContextPool<UsersDbContext>(optionBuilder => optionBuilder.UseNpgsql(builder.Configuration.GetConnectionString("UsersConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
