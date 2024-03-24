using Microsoft.AspNetCore.Mvc;

namespace VShop.ProductApi.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}