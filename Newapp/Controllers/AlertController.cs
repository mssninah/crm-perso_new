using Microsoft.AspNetCore.Mvc;
using Newapp.Services;  // Import the AlertService
using Newapp.Models;    // Make sure this namespace is included

namespace Newapp.Controllers
{
    public class AlertController : Controller
    {
        private readonly AlertService _alertService;

        // Constructor with dependency injection for AlertService
        public AlertController(AlertService alertService)
        {
            _alertService = alertService;
        }

        // Action to display the form
        public IActionResult ConfigureAlertRate()
        {
            return View();
        }

        // Action to handle the form submission
        [HttpPost]
        public async Task<IActionResult> AddAlert(double alertRate)
        {
            Console.WriteLine($"Alert Rate: {alertRate}");
            // Use the service to send the alertPercentage to the API as a query parameter
            bool result = await _alertService.AddAlertAsync(alertRate);

            if (result)
            {
                TempData["Message"] = "Le taux d'alerte a été ajouté avec succès.";
            }
            else
            {
                TempData["Message"] = "Une erreur est survenue lors de l'ajout du taux d'alerte.";
            }

            return RedirectToAction("ConfigureAlertRate");
        }
    }
}
