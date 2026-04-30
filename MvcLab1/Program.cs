using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;  // ← ЭТО ДОБАВИТЬ!
using MvcLab1.Data;
using MvcLab1.Repositories;
using MvcLab1.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавление MVC
builder.Services.AddControllersWithViews();

// Регистрация репозитория
builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();


// РЕГИСТРАЦИЯ КОНТЕКСТА БАЗЫ ДАННЫХ
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
);

// ========== СБОРКА ПРИЛОЖЕНИЯ ==========
var app = builder.Build();

// ========== ИНИЦИАЛИЗАЦИЯ БАЗЫ ДАННЫХ ==========
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await SeedData.InitializeAsync(dbContext);
}

// ========== КОНФИГУРАЦИЯ MIDDLEWARE ==========
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Маршрут для категорий
app.MapControllerRoute(
    name: "newsCategory",
    pattern: "News/Category/{category}",
    defaults: new { controller = "News", action = "Category" });

// Главный маршрут
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Маршрут для статей
app.MapControllerRoute(
    name: "newsArticle",
    pattern: "News/Article/{id}",
    defaults: new { controller = "News", action = "Article" });

app.Run();