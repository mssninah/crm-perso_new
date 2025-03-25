using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newapp.Models;
using Newapp.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Newapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;

          public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

         public async Task<IActionResult> Index()
        {
            // Récupérer les nombres de leads et tickets
            var leadCount = await _apiService.GetLeadCountAsync();
            var ticketCount = await _apiService.GetTicketCountAsync();
            var customerCount = await _apiService.GetCustomerCountAsync();
            // Passer les valeurs à la vue via ViewBag
            ViewBag.LeadCount = leadCount;
            ViewBag.TicketCount = ticketCount;
            ViewBag.CustomerCount = customerCount;


            var customers = await _apiService.GetAllCustomersAsync();
            var tickets = await _apiService.GetAllTicketsAsync();
            var leads = await _apiService.GetAllLeadsAsync();

            var viewModel = new DashboardViewModel
            {
                Customers = customers,
                Tickets = tickets,
                Leads = leads
            };
            
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
