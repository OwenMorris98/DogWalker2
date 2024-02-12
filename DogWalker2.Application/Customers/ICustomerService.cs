using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;

namespace DogWalker2.Application.Customers
{
    public interface ICustomerService
    {
        void addCustomer(string id);

        Task addCustomerData(Customer customer);

        void UpdateCustomer(Customer customer);

        Task deleteCustomer(string id);
   


    }
}
