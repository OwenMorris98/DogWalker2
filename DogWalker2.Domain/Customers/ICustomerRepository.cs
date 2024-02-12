using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Customers;

namespace DogWalker2.Domain.Customers
{
    public interface ICustomerRepository
    {

        Task<Customer> GetCustomerById(string id);
        void addCustomer(Customer customer);

        void addCustomerData(Customer customer);

        void UpdateCustomer(Customer customer);

        void deleteCustomer(Customer customer);
    }
}
