using DogWalker2.Client.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DogWalker2.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> DeleteCustomerRequest(string customerId) =>
            await _httpClient.DeleteAsync($"https://localhost:7188/api/Customer/{customerId}");

        public async Task<HttpResponseMessage> EditCustomerRequest(string customerId, Customer customer) =>
                    await _httpClient.PutAsJsonAsync<Customer>($"https://localhost:7188/api/Customer/{customerId}", customer);
         
        

        public async Task<CustomerRoot?> GetAllCustomersRequest() =>    
         await _httpClient.GetFromJsonAsync<CustomerRoot>("https://localhost:7188/api/Customer");



        public async Task<Customer?> GetCustomerByIdRequest(string customerId) =>
            await _httpClient.GetFromJsonAsync<Customer>($"https://localhost:7188/api/Customer/{customerId}");

        public async Task<HttpResponseMessage> PostCustomer(Customer customer) =>
            await _httpClient.PostAsJsonAsync("https://localhost:7188/api/Customer/", customer);
       
    }
}
