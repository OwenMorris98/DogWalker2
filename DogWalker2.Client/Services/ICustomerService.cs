using DogWalker2.Client.Models;

namespace DogWalker2.Client.Services
{
    public interface ICustomerService
    {
        Task<CustomerRoot?> GetAllCustomersRequest();

        Task<Customer?> GetCustomerByIdRequest(string customerId);

        Task<HttpResponseMessage> EditCustomerRequest(string customerId, Customer customer);

        Task<HttpResponseMessage> DeleteCustomerRequest(string customerId);

        Task<HttpResponseMessage> PostCustomer(Customer customer);
    }
}
