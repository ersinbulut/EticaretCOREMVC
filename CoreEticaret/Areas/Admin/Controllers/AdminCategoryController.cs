using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CoreEticaret.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminCategoryController : Controller
	{
		CategoryManager categoryManeger = new CategoryManager(new EFCategoryRepository());
        Context db = new Context();
		public IActionResult Index()
		{
			//ViewBag.categoryCount=categoryManeger.GetList().Count();
			var categoryList = categoryManeger.GetList();
			return View(categoryList);
		}

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            //cm.CategoryAddBL(cat);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(cat);
            if (result.IsValid)//sonuç geçerliyse
            {
                cat.Status = true;
                cat.ParentCategory = null;
                categoryManeger.TAdd(cat);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);
            var categories = db.Categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            categories.Add(new SelectListItem()
            {
                Value = "0",
                Text = "Ana Kategori",
                Selected = true
            });
            ViewBag.Categories = categories;
            return View(cat);
        }
        [HttpPost]
        public ActionResult EditCategory(Category cat)
        {
            //cm.CategoryAddBL(cat);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(cat);
            if (result.IsValid)//sonuç geçerliyse
            {
                cat.Status = true;
                cat.ParentCategory = null;
                categoryManeger.TUpdate(cat);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        
        public ActionResult DeleteCategory(int? id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);
            categoryManeger.TDelete(cat);
            return RedirectToAction("Index");
        }
    }
}
