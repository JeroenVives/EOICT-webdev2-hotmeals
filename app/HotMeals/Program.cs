using HotMeals.Data.School;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SchoolDatabase") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.");

builder.Services.AddDbContext<SchoolContext>(options => options.UseMySQL(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddDefaultIdentity<SchoolUser>()
                .AddEntityFrameworkStores<SchoolContext>();

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();