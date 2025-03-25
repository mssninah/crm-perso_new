using Microsoft.AspNetCore.Mvc;
using Newapp.Models;
using Newapp.Services;
using System.Threading.Tasks;

namespace Newapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApiService _apiService;

        public LoginController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: /Login/
        public IActionResult Index()
        {
            ViewData["HideNavbar"] = true;
            return View();
        }

        // POST: /Login/
        [HttpPost]
        public async Task<IActionResult> Index(string email)
        {

            // Check if the email is empty
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewData["HideNavbar"] = true;

                ViewData["ErrorMessage"] = "Email is required.";
                return View();  // Return to the login form with error message
            }

            try
            {
                // Call the login API to check if the user exists
                var user = await _apiService.CheckUserAsync(email);

                if (user == null)
                {
                    ViewData["ErrorMessage"] = "User not found.";
                    return View();  // Return to the login form with error message
                }

                // Pass the user directly to the Profile view via ViewBag
                ViewBag.User = user;
                ViewBag.CountdownTime = 10; 
                return View("Profile"); // Render the Profile view directly
            }
            catch (Exception ex)
            {
                ViewData["HideNavbar"] = true;
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View();  // Return to the login form with error message
            }
        }
    }
}
