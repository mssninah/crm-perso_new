using System.Net.Http;
using System.Text.Json; // Only use this for System.Text.Json
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

                var content = await response.Content.ReadAsStringAsync();
               
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize using System.Text.Json
                    var leads = JsonSerializer.Deserialize<List<Lead>>(content);

                    return leads;
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

                var content = await response.Content.ReadAsStringAsync();
              
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize using System.Text.Json
                    var tickets = JsonSerializer.Deserialize<List<Ticket>>(content);
                    return tickets;
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

        // Récupérer tous les clients
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:8080/api/customers");

                var content = await response.Content.ReadAsStringAsync();
               
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize using System.Text.Json
                    var customers = JsonSerializer.Deserialize<List<Customer>>(content);
                    return customers;
                }

                Console.WriteLine("Error: Unable to fetch customers.");
                return new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while fetching customers: {ex.Message}");
                return new List<Customer>();
            }
        }

        // Get the count of customers
        public async Task<int> GetCustomerCountAsync()
        {
            var customers = await GetAllCustomersAsync();
            return customers.Count;
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
        


        //delete tickets
        public async Task<bool> DeleteTickets(int leadsID)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/tickets/{leadsID}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while deleting customer: {ex.Message}");
                return false;
            }
        }

        //delete leads
        public async Task<bool> DeleteLead(int leadId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/leads/{leadId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while deleting lead: {ex.Message}");
                return false;
            }
        }

        public async Task<User> CheckUserAsync(string email)
        {
            try
            {
                var response = await _httpClient.PostAsync("http://localhost:8080/api/logincsharp", 
                    new StringContent(email));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var user = JsonSerializer.Deserialize<User>(content);
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login request: {ex.Message}");
                return null;
            }
        }



                public async Task<decimal> GetTotalBudgetAsync()
                    {
                        try
                        {
                            var response = await _httpClient.GetAsync("http://localhost:8080/api/budget/total");
                            var content = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                var totalBudget = JsonSerializer.Deserialize<decimal>(content);
                                return totalBudget;
                            }

                            Console.WriteLine("Error: Unable to fetch total budget.");
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Exception occurred while fetching total budget: {ex.Message}");
                            return 0;
                        }
                    }


                public async Task<decimal> GetTotalExpensesAsync()
            {
                try
                {
                    var response = await _httpClient.GetAsync("http://localhost:8080/api/expense/total");
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                    var totalExpenses = JsonSerializer.Deserialize<decimal>(content);
                        return totalExpenses;
                    }

                    Console.WriteLine("Error: Unable to fetch total expenses.");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred while fetching total expenses: {ex.Message}");
                    return 0;
                }
            }
            public async Task<List<object[]>> GetCumulativeBudgetForCustomersAsync()
            {
                try
                {
                    var response = await _httpClient.GetAsync("http://localhost:8080/api/budget/cumulative");
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var cumulativeBudgets = JsonSerializer.Deserialize<List<object[]>>(content);
                        return cumulativeBudgets;
                    }

                    Console.WriteLine("Error: Unable to fetch cumulative budget for customers.");
                    return new List<object[]>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred while fetching cumulative budget: {ex.Message}");
                    return new List<object[]>();
                }
            }

            public async Task<List<object[]>> GetAverageExpensePerWeekAsync()
            {
                try
                {
                    var response = await _httpClient.GetAsync("http://localhost:8080/api/expense/average-per-week");
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var averageExpenses = JsonSerializer.Deserialize<List<object[]>>(content);
                        return averageExpenses;
                    }

                    Console.WriteLine("Error: Unable to fetch average expense per week.");
                    return new List<object[]>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred while fetching average expense: {ex.Message}");
                    return new List<object[]>();
                }
            }





        
    }

    
}
