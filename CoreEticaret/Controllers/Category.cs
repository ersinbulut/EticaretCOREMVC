using BusinessLayer.Concrete;
using CoreEticaret.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;

namespace CoreEticaret.Controllers
{
    public class Category : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        
        Context db = new Context();
        
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        
        public PartialViewResult _CategoryList()
        {
            var kategoriler = db.Categories.Include(i => i.Products).Select(x => new CategoryModel()
            //var kategoriler = db.Categories.Select(x => new Category()
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Name = x.Name,
                Count = x.Products.Count()
            }).ToList();

            return PartialView(kategoriler);

            //List<Category> all = new List<Category>();
            //all = db.Categories.OrderBy(a => a.ParentId).ToList();
            //return PartialView(all);
        }

    }
}
