namespace MvcLab1.Models;

/// <summary>
/// ViewModel для страницы статистики товаров
/// </summary>
public class ProductsStatisticsViewModel
{
    public int TotalCount { get; set; }
    public decimal AveragePrice { get; set; }
    public int InStockCount { get; set; }
    public (decimal MinPrice, decimal MaxPrice) PriceRange { get; set; }
    public IEnumerable<CategoryStatViewModel> Categories { get; set; } = new List<CategoryStatViewModel>();
}

/// <summary>
/// ViewModel для статистики по категории
/// </summary>
public class CategoryStatViewModel
{
    public string Category { get; set; } = "";
    public int Count { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}