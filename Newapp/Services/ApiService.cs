using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newapp.Models;
using System;

namespace Newapp.Services
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
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:8080/api/leads");

                // Log the raw JSON response
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response JSON (Leads):");
                Console.WriteLine(content);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize and return the data
                    return JsonSerializer.Deserialize<List<Lead>>(content);
                }

                Console.WriteLine("Error: Unable to fetch leads.");
                return new List<Lead>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while fetching leads: {ex.Message}");
                return new List<Lead>();
            }
        }

        // Récupérer tous les tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:8080/api/tickets");

                // Log the raw JSON response
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response JSON (Tickets):");
                Console.WriteLine(content);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize and return the data
                    return JsonSerializer.Deserialize<List<Ticket>>(content);
                }

                Console.WriteLine("Error: Unable to fetch tickets.");
                return new List<Ticket>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while fetching tickets: {ex.Message}");
                return new List<Ticket>();
            }
        }

        // Get the count of leads
        public async Task<int> GetLeadCountAsync()
        {
            var leads = await GetAllLeadsAsync();
            return leads.Count;
        }

        // Get the count of tickets
        public async Task<int> GetTicketCountAsync()
        {
            var tickets = await GetAllTicketsAsync();
            return tickets.Count;
        }
    }
}
