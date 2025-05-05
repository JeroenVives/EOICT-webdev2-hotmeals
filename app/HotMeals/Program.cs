using HotMeals.Authorization.Handlers;
using HotMeals.Authorization.Requirements;
using HotMeals.Data.School;
using HotMeals.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddDefaultIdentity<SchoolUser>()
                .AddEntityFrameworkStores<SchoolContext>();
builder.Services.AddScoped<IAuthorizationHandler, RoleHandler>();

builder.Services.ConfigureApplicationCookie(options =>
{

    options.LoginPath = "/mvc/Identity/loginout";
    options.LogoutPath = "/mvc/Identity/loginout";
    options.AccessDeniedPath = "/mvc/Identity/accessdenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TeacherRole", policy =>
        policy.Requirements.Add(new RoleRequirement(RoleEnum.teaching)));
});

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    await db.Database.MigrateAsync();
}

app.Run();