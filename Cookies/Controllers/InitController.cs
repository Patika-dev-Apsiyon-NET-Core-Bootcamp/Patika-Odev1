using Cookies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies.Controllers
{
    public class InitController : Controller
    {
        public IActionResult Index()
        {

            List<UserViewModel> users = new List<UserViewModel>();
            for (int i = 0; i < 5; i++)
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.Age = 10 + i;
                userViewModel.LastName = $"B{i}";
                userViewModel.Name = $"A{i} adı";
                userViewModel.UserName = $"A{i}";
                userViewModel.Hobbies.Add("X");
                userViewModel.Hobbies.Add("Y");
                userViewModel.Password = $"{i}";

                users.Add(userViewModel);
              
            }


            HttpContext.Session.Set<List<UserViewModel>>("users", users);
        
            return RedirectToAction("Index","Home");
        }
    }
}
