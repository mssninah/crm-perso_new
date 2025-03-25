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
        // Fetch the count data
        var leadCount = await _apiService.GetLeadCountAsync();
        var ticketCount = await _apiService.GetTicketCountAsync();
        var customerCount = await _apiService.GetCustomerCountAsync();

        // Fetch the other data for charts
        var totalBudget = await _apiService.GetTotalBudgetAsync();
        var totalExpenses = await _apiService.GetTotalExpensesAsync();
        // var cumulativeBudgets = await _apiService.GetCumulativeBudgetForCustomersAsync();
        // var averageExpenseData = await _apiService.GetAverageExpensePerWeekAsync();

        // // Prepare the data for charts
        // var averageExpenseLabels = averageExpenseData.Select(e => "Week " + e[1] + " (" + e[0] + ")").ToList();
        // var averageExpenseValues = averageExpenseData.Select(e => e[2]).ToList();

        // var budgetLabels = cumulativeBudgets.Select(b => b[1].ToString()).ToList();
        // var budgetValues = cumulativeBudgets.Select(b => (decimal)b[2]).ToList();

        // Create the DashBoard2Model to pass data to the view
        var viewModel = new DashBoard2Model
        {
            CustomerCount = customerCount,
            TotalBudget = totalBudget,
            TotalExpenses = totalExpenses,
            LeadCount = leadCount,
            TicketCount = ticketCount,
            // AverageExpenseLabels = averageExpenseLabels,
            // AverageExpenseValues = averageExpenseValues,
            // CumulativeBudgetsLabels = budgetLabels,
            // CumulativeBudgetsValues = budgetValues
        };

        return View(viewModel);
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
