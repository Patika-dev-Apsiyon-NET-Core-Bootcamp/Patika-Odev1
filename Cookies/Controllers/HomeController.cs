using Cookies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            if(HttpContext.Session.Get<UserViewModel>("currentUser") == default)
            {
                return RedirectToAction("Login", "Auth");
            }

            UserViewModel userViewModel = HttpContext.Session.Get<UserViewModel>("currentUser");

            return View("Index",userViewModel);
        }

        public IActionResult Session()
        {

            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("userName")))
                HttpContext.Session.SetString("userName", "murat");

            string userName = HttpContext.Session.GetString("userName");

            return View("Session",userName);
        }
        public IActionResult CookieAndSession()
        {
            string studentName = string.Empty;
          
            if (Request.Cookies.ContainsKey("ogrenciAdi"))
                studentName = Request.Cookies["ogrenciAdi"];
            else
            {
                CookieOptions options = new CookieOptions();
                options.Path = "/";
                options.Expires = new DateTimeOffset(DateTime.Now.AddHours(5));
               
                Response.Cookies.Append("ogrenciAdi", "Murat Genç", options);
            }

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Age = 21;
            userViewModel.LastName = "Genç";
            userViewModel.Name = "Murat";
            userViewModel.Hobbies.Add("X");
            userViewModel.Hobbies.Add("Y");

            if(HttpContext.Session.Get<UserViewModel>("user") == default)
            {
                HttpContext.Session.Set<UserViewModel>("user", userViewModel);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
