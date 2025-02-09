using Microsoft.AspNetCore.Mvc;

namespace SaleSystem.WebApplication.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewSale()
        {
            return View();
        }
    }
}
