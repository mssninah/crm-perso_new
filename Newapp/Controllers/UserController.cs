using Microsoft.AspNetCore.Mvc;
using Newapp.Models;
using Newapp.Services;
using Microsoft.AspNetCore.Http; // Nécessaire pour accéder à la session
using System.Text.Json;

namespace Newapp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiService _apiService;

        public UserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Action pour afficher la page de profil
        public IActionResult Profile()
        {
            // Vérifiez si l'utilisateur est connecté
            var userJson = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToAction("Index", "Login"); // Si l'utilisateur n'est pas connecté, rediriger vers la page de connexion
            }

            // Désérialiser l'objet User à partir du JSON stocké dans la session
            var user = JsonSerializer.Deserialize<User>(userJson);

            // Passer les informations de l'utilisateur à la vue
            return View(user);
        }
    }
}
