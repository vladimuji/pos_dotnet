using Microsoft.AspNetCore.Mvc;

namespace SaleSystem.WebApplication.Controllers
{
    public class SalesHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalesHistory()
        {
            return View();
        }
    }
}
