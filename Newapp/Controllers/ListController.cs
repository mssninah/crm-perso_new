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
        [HttpDelete("delete-ticket/{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            Console.WriteLine("here");
            var result = await _apiService.DeleteTickets(id);

            if (result)
            {
                return NoContent(); // Return 204 No Content if deletion is successful
            }

            return BadRequest("Failed to delete customer.");
        }

        // Endpoint to delete a lead
        [HttpDelete("delete-lead/{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var result = await _apiService.DeleteLead(id);

            if (result)
            {
                return NoContent(); // Return 204 No Content if deletion is successful
            }

            return BadRequest("Failed to delete lead.");
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
