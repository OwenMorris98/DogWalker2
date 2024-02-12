using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;

namespace DogWalker2.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) 
       {
         _customerRepository = customerRepository;
       }

        public void addCustomer(string id)
        {
            Customer cust = new Customer() {Id = id };
            this._customerRepository.addCustomer(cust);
        }

        public async Task addCustomerData( Customer cust)
        {

            this._customerRepository.addCustomerData(cust);
            
        }

        public async Task deleteCustomer(string id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            _customerRepository.deleteCustomer(customer);
        }

        public async Task<Customer> getCustomerById(string id)
        {
            var customer = await this._customerRepository.GetCustomerById(id);
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {            
            this._customerRepository.UpdateCustomer(customer);   
        }
    }
}
