using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreEticaret.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        Context db = new Context();
        public IActionResult Index()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }

        public PartialViewResult _CategoryList()
        {
            var values = pm.GetProductListWithCategory();
            return PartialView(values);
        }

        public IActionResult ProductReadAll(int id)
        {
            ViewBag.i = id;
            var values = pm.GetProductByID(id);
            return View(values);
        }

        public IActionResult Shop()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }
    }
}
