using HotMeals.Data.School;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<SchoolContext>(options => options.UseMySQL())
    .AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();