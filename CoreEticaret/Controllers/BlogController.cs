using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();

            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            //ViewBag.CommentId = id;

            var result = blogManager.GetList(id);

            return View(result);
        }
    }
}
