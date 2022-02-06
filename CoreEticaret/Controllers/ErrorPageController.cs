using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult Error1(int code)
        {
            return View();
        }
    }
}
