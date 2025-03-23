namespace Newapp.Services
{
    using Newapp.Models; // Importer le modèle Lead
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class LeadService
    {
        private static readonly HttpClient client = new HttpClient();

        // Méthode pour récupérer les leads
        public async Task<List<Lead>> GetLeadsAsync()
        {
            try
            {
                string apiUrl = "http://localhost:8080/api/leads"; // URL de l'API Spring Boot pour récupérer les leads
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Lead> leads = JsonConvert.DeserializeObject<List<Lead>>(jsonResponse);
                    return leads;
                }
                else
                {
                    Console.WriteLine("Erreur lors de la récupération des leads.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue: {ex.Message}");
                return null;
            }
        }

        // Méthode pour supprimer un lead par ID
        public async Task DeleteLeadAsync(int leadId)
        {
            try
            {
                string apiUrl = $"http://localhost:8080/api/leads/{leadId}"; // URL de l'API Spring Boot pour supprimer un lead
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Le lead avec ID {leadId} a été supprimé avec succès.");
                }
                else
                {
                    Console.WriteLine($"Erreur lors de la suppression du lead avec ID {leadId}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue: {ex.Message}");
            }
        }
    }
}
