using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newapp.Models;
using Newapp.Services;
using Newtonsoft.Json;

namespace Newapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LeadService _leadService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _leadService = new LeadService(); // Initialisation du service Lead
        }

        public async Task<IActionResult> Index()
        {
            // Récupérer les données des statuts des leads
            // var leadStatusCounts = await _leadService.GetLeadStatusCountsAsync();

            // // Injecter les données dans la vue
            // ViewBag.LeadStatusData = JsonConvert.SerializeObject(leadStatusCounts);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
