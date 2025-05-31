using MovieRaptor.WebUI.Server.Components;
using MovieRaptor.Application;
using MovieRaptor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents