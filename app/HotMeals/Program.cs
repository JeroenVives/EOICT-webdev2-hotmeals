using HotMeals.Data.School;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SchoolDatabase") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.");
var serverVersion = new MariaDbServerVersion(new Version(12, 1, 2));

builder.Services
    .AddDbContext<SchoolContext>(options => options.UseMySql(connectionString, serverVersion))
    .AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.Run();