using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreEticaret.ViewComponents.Default
{
    public class _CategoryList : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public IViewComponentResult Invoke()
        {

            var categories = categoryManager.GetParentCategoryList();

            return View(categories); 
        }
    }
}
