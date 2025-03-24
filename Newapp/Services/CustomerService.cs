// using Newapp.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Newtonsoft.Json;

// namespace Newapp.Services
// {
//     public class CustomerService
//     {
//         private static readonly HttpClient client = new HttpClient();

//         // Méthode pour récupérer tous les clients
//         public async Task<List<Customer>> GetCustomersAsync()
//         {
//             try
//             {
//                 string apiUrl = "http://localhost:8080/api/customers"; // Assurez-vous que l'URL est correcte
//                 HttpResponseMessage response = await client.GetAsync(apiUrl);

//                 if (!response.IsSuccessStatusCode)
//                 {
//                     Console.WriteLine($"Erreur lors de l'appel de l'API. Code d'état : {response.StatusCode}");
//                     return null;
//                 }

//                 string jsonResponse = await response.Content.ReadAsStringAsync();
//                 Console.WriteLine(jsonResponse);

//                 List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonResponse);
//                 return customers;
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Erreur lors de l'appel de l'API : {ex.Message}");
//                 return null;
//             }
//         }

    
//         // Méthode pour supprimer un client par ID
//         public async Task DeleteCustomerAsync(int customerId)
//         {
//             try
//             {
//                 string apiUrl = $"http://localhost:8080/api/customers/{customerId}";
//                 HttpResponseMessage response = await client.DeleteAsync(apiUrl);

//                 if (response.IsSuccessStatusCode)
//                 {
//                     Console.WriteLine($"Le client avec ID {customerId} a été supprimé avec succès.");
//                 }
//                 else
//                 {
//                     Console.WriteLine($"Erreur lors de la suppression du client avec ID {customerId}.");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Une erreur est survenue : {ex.Message}");
//             }
//         }
//     }
// }
