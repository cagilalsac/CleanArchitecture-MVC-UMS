using Application.Contexts.Bases;
using Application.Services;
using Application.Services.Bases;
using Microsoft.EntityFrameworkCore;
using MVC.Settings;
using Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

#region AppSettings
builder.Configuration.GetSection(nameof(AppSettings)).Bind(new AppSettings());
#endregion

// Add services to the container.
#region IoC Container
builder.Services.AddDbContext<IDb, Db>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
#endregion

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
