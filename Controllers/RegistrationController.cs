using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using Milestone.Services;

namespace Milestone.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessRegistration(UserModel user)
        {
            SecurityService securityService = new SecurityService();
            UsersDAO usersDAO = new UsersDAO();
            if (usersDAO.AddUser(user))
            {
                return View("RegistrationSuccess", user);
            }
            else
            {
                return View("RegistrationFailure", user);
            }
        }
    }
}
