using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This returns the Home/Index.cshtml view
        }

        // New action to return the Login view
        public IActionResult Login()
        {
            return View(); // This will return the Home/Login.cshtml view
        }

        // Add a Welcome action for the redirect
        public IActionResult Welcome()
        {
            return View(); // Render a welcome view after login
        }
    }
}
