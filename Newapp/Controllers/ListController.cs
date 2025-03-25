using Microsoft.AspNetCore.Mvc;
using Newapp.Models;
using Newapp.Services;
using System.Threading.Tasks;

namespace Newapp.Controllers
{
    public class ListController : Controller
    {
        private readonly ApiService _apiService;

        public ListController(ApiService apiService)
        {
            _apiService = apiService;
        }
     
        public async Task<IActionResult> Index()
        {
            // Récupération des données via ApiService
            var customers = await _apiService.GetAllCustomersAsync();
            var tickets = await _apiService.GetAllTicketsAsync();
            var leads = await _apiService.GetAllLeadsAsync();

            // Préparer le ViewModel
            var viewModel = new DashboardViewModel
            {
                Customers = customers,
                Tickets = tickets,
                Leads = leads
            };

            // Passer le ViewModel à la vue
            return View(viewModel);
        }
    }
}
