using Cookies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies.Controllers
{
    public class ComplexController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel model = null;
            if (HttpContext.Session.Get<UserViewModel>("user") != default)
            {
                 model =  HttpContext.Session.Get<UserViewModel>("user");
            }
            return View("Index",model);
        }
    }
}
