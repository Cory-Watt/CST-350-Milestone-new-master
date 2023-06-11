using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using Milestone.Services;

namespace Milestone.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(userModel))
            {
                HttpContext.Session.SetString("username", userModel.UserName);
                return View("LoginSuccess", userModel);
            }
            else
            {
                HttpContext.Session.Remove("username");
                return View("LoginFailure", userModel);
            }

        }

    }

}
