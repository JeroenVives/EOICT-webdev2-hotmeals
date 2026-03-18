using HotMeals.Data.School;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<SchoolUser>()
                .AddEntityFrameworkStores<SchoolContext>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    await dbContext.Database.MigrateAsync();
}

app.Run();