using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreEticaret.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminProductController : Controller
	{
		ProductManager productManager = new ProductManager(new EfProductRepository());
		public IActionResult Index()
		{
			var productList = productManager.GetList();
			return View(productList);
		}
	}
}
