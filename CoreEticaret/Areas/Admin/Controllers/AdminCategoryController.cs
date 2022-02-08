using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreEticaret.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminCategoryController : Controller
	{
		CategoryManager categoryManeger = new CategoryManager(new EfCategoryRepository());
		public IActionResult Index()
		{
			//ViewBag.categoryCount=categoryManeger.GetList().Count();
			var categoryList = categoryManeger.GetList();
			return View(categoryList);
		}
	}
}
