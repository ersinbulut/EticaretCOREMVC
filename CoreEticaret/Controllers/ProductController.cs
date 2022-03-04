using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public ActionResult ProductList(int categoryId, int subCategoryId)
        {
            var query = db.Products.AsQueryable();

            if (categoryId > 0)
                query = query.Where(i => i.CategoryId == subCategoryId);
            else
                query = query.Where(i => i.Category.ParentCategoryID == subCategoryId || i.CategoryId == subCategoryId);

            return View(query.ToList());
        }
    }
}
