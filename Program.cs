using Microsoft.EntityFrameworkCore;
using Week5CaseStudy.Data;
using Microsoft.AspNetCore.Identity;
using Week5CaseStudy.Services;
using Week5CaseStudy.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

builder.Services.AddRazorPages();

builder.Services.AddScoped<IRepository, MyRepository>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddLogging(log =>
{
    log.ClearProviders();
    log.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Error);
});

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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
