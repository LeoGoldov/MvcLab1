using MvcLab1.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<IMovieRepository, InMemoryMovieRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//Маршрут для категорий
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