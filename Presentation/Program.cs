using Microsoft.EntityFrameworkCore;
using Presentation.Contexts;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var connectionsString = builder.Configuration.GetConnectionString("SQLDataBase");
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionsString));

builder.Services.AddScoped<ProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
