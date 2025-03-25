using Microsoft.AspNetCore.Mvc;

namespace Newapp.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        public IActionResult Index()
        {
            ViewData["HideNavbar"] = true;
            return View();
        }
    }
}