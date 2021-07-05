using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cookies.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
          
            if(string.IsNullOrWhiteSpace(HttpContext.Session.GetString("userName")))
                HttpContext.Session.SetString("userName", "murat");

            string userName = HttpContext.Session.GetString("userName");

            return View();
        }

        public IActionResult ComplexObject()
        {
        
            return View();
        }
    }
}
