using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Controllers
{
    public class BlogCategoryController : Controller
    {
        BlogCategoryManager blogCategoryManager = new BlogCategoryManager(new EfBlogCategoryRepository());

        public IActionResult Index()
        {
            var values = blogCategoryManager.GetList();

            return View(values);
        }
    }
}
