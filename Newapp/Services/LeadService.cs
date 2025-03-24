   using Newapp.Models; // Importer le modèle Lead
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

namespace Newapp.Services
{
    public class LeadService
    {
        private static readonly HttpClient client = new HttpClient();


    public async Task<List<Lead>> GetLeadsAsync(){
        try
        {
            string apiUrl = "http://localhost:8080/api/customers"; // Assurez-vous que l'URL est correcte
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erreur lors de l'appel de l'API. Code d'état : {response.StatusCode}");
                return null;
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);
            List<Lead> leads = JsonConvert.DeserializeObject<List<Lead>>(jsonResponse);

            return leads;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'appel de l'API : {ex.Message}");
            return null;
        }
    
    }



        // Méthode pour regrouper les leads par statut
            public async Task<Dictionary<string, int>> GetLeadStatusCountsAsync()
            {
                var leads = await GetLeadsAsync();
                return leads
                    .GroupBy(lead => lead.Status)
                    .ToDictionary(group => group.Key, group => group.Count());
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
