using Microsoft.AspNetCore.Mvc;

namespace ChuyenDeCongNghePhanMem.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
