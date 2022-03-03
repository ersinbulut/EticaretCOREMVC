using Microsoft.AspNetCore.Mvc;

namespace CoreEticaret.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
