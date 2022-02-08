using Microsoft.AspNetCore.Mvc;

namespace CoreEticaret.Areas.Admin.Controllers
{
	public class AdminHomePageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
