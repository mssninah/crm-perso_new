using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newapp.Models;  // Make sure this namespace is included

namespace Newapp.Services
{
    public class AlertService
    {
        private readonly HttpClient _httpClient;

        // Constructor to inject HttpClient
        public AlertService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddAlertAsync(double alertPercentage)
        {
            try
            {
                // API URL with query parameter
                string apiUrl = $"http://localhost:8080/api/alert-rate?alertPercentage={alertPercentage}";

                // Créer la requête GET ou POST selon ce qui est nécessaire
                var response = await _httpClient.PostAsync(apiUrl, null); // No body, just sending the URL parameter

                // Retourner si la requête a réussi ou non
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log l'exception si nécessaire
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


    }
}
