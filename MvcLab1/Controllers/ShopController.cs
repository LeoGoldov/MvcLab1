using Microsoft.AspNetCore.Mvc;

namespace MvcLab1.Controllers
{
    [Route("store")]
    [Route("shop")]
    public class ShopController : Controller
    {
        // GET: /store
        // GEt: /shop
        public IActionResult Index()
        {
            ViewBag.StoreName = "Мой Магазин";
            ViewData["ProductsCount"] = 15;
            return View();
        }

        // GEt:  /store/categoru/electronics
        //GET: /shop/category/electronics
        [Route("category/{categoryName}")]
        public IActionResult Category(string categoryName)
        {
            ViewBag.Category = categoryName;
            ViewBag.Products = new[] { "Ноутбук", "Сматрофон", "Планшет" };
            return View();
        }
            // Get: /store/product/42/details
        [Route("product/{id:int}/details")]
        public IActionResult ProductDetails(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.ProductName = $"Товар #{id}";
            return View();
        }
    }
}