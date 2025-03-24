using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using NewApp.Models;

namespace NewApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Récupérer tous les leads
        public async Task<List<Lead>> GetAllLeadsAsync()
        {
            // Correct the URL
            var response = await _httpClient.GetAsync("http://localhost:8080/api/leads");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Lead>>(content);
            }

            return new List<Lead>();
        }

        // Récupérer tous les tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            // Correct the URL
            var response = await _httpClient.GetAsync("http://localhost:8080/api/tickets");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Ticket>>(content);
            }

            return new List<Ticket>();
        }
    }
}
