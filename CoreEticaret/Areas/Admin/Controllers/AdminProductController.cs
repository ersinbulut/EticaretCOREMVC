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
	public class AdminProductController : Controller
	{
		ProductManager productManager = new ProductManager(new EfProductRepository());
        Context db = new Context();
		public IActionResult Index()
		{
			var productList = productManager.GetList();
			return View(productList);
		}



        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            //cm.CategoryAddBL(cat);
            ProductValidator categoryValidator = new ProductValidator();
            ValidationResult result = categoryValidator.Validate(product);
            if (result.IsValid)//sonuç geçerliyse
            {
                product.Status = true;
                product.Slider = true;
                //product.ParentId = 0;
                productManager.TAdd(product);
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
        //[HttpGet]
        //public ActionResult EditProduct(int? id)
        //{
        //    var cat = db.Categories.FirstOrDefault(x => x.Id == id);
        //    var categories = db.Categories.Select(x => new SelectListItem()
        //    {
        //        Text = x.Name,
        //        Value = x.Id.ToString()
        //    }).ToList();
        //    categories.Add(new SelectListItem()
        //    {
        //        Value = "0",
        //        Text = "Ana Kategori",
        //        Selected = true
        //    });
        //    ViewBag.Categories = categories;
        //    return View(cat);
        //}
        //[HttpPost]
        //public ActionResult EditProduct(Category cat)
        //{
        //    //cm.CategoryAddBL(cat);
        //    CategoryValidator categoryValidator = new CategoryValidator();
        //    ValidationResult result = categoryValidator.Validate(cat);
        //    if (result.IsValid)//sonuç geçerliyse
        //    {
        //        cat.Status = true;
        //        cat.ParentCategory = null;
        //        categoryManeger.TUpdate(cat);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

        public ActionResult DeleteProduct(int? id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            productManager.TDelete(product);
            return RedirectToAction("Index");
        }
	}
}
