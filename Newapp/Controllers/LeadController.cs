using Microsoft.AspNetCore.Mvc;
using NewApp.Models;
using NewApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewApp.Controllers
{
    public class LeadController : Controller
    {
        private readonly ApiService _apiService;

        // Constructeur pour injecter le service API
        public LeadController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Action pour afficher la liste des leads
        public async Task<IActionResult> Index()
        {
            // Récupérer la liste des leads depuis l'API
            var leads = await _apiService.GetAllLeadsAsync();
            return View(leads);  // Passer la liste des leads à la vue Index
        }
    }
}
