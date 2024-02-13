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

        public void addCustomerData(AddCustomerDTO dto)
        {
            Customer customer = new Customer()
            {
                Id = dto.Id,
                first_name = dto.first_name,
                last_name = dto.last_name,
                address = dto.address,
                city = dto.city,
                state = dto.state, 
                zipcode = dto.zipcode,
            };
            this._customerRepository.addCustomerData(customer);
            
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
