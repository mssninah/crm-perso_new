using Microsoft.AspNetCore.Mvc;
using Newapp.Models;
using Newapp.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;  // Nécessaire pour accéder à la session
using System.Text.Json;

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
            ViewData["HideNavbar"] = true;

            // Check if the email is empty
            if (string.IsNullOrWhiteSpace(email))
            {
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

                // Store the user in the session as a serialized JSON string
                var userJson = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("User", userJson);  // Stocker l'objet User sérialisé

                // If user is found, proceed to the home page or dashboard
                return RedirectToAction("Index", "Home"); // Redirect to the home page or another page
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View();  // Return to the login form with error message
            }
        }
    }
}
