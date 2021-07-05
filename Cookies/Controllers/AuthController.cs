using Cookies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies.Controllers
{
    public class AuthController : Controller
    {


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {

            if (ModelState.IsValid)
            {
                List<UserViewModel> users = HttpContext.Session.Get<List<UserViewModel>>("users");

                UserViewModel currentUser = users.FirstOrDefault(x => x.UserName == model.UserName.Trim() && x.Password == model.Password.Trim());

                if (currentUser != null)
                {

                    HttpContext.Session.Set<UserViewModel>("currentUser", currentUser);

                    return RedirectToAction("Index", "Home");
                }
                else ViewBag.NotFound = "Kullanıcı adı veya şifre yanlış";

            }

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("currentUser");

            return RedirectToAction("Login");

        }
    }
}
