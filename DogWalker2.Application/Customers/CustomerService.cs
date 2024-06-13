using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers.Commands.CreateCommands;
using DogWalker2.Application.Customers.Commands.UpdateCommands;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Customers.Queries.GetAllCustomerDataById;
using DogWalker2.Application.Mapperly;
using DogWalker2.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Update;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DogWalker2.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        
        private CustomerMapper mapper = new CustomerMapper();

        public CustomerService(ICustomerRepository customerRepository) 
       {
         _customerRepository = customerRepository;
       }

        public void addCustomer(string id)
        {
            Customer cust = new Customer() {Id = id };
            this._customerRepository.addCustomer(cust);
        }

        public async Task<CustomerDTO> addCustomerData(CreateCustomerCommand command)
        {
            var customer = mapper.CustomerDTOtoCustomer(command.customer);
            customer.Id = Guid.NewGuid().ToString();      
            this._customerRepository.addCustomerData(customer);
            return command.customer;
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
        
        
        public async Task<GetAllCustomersDTO> GetAll()
        {
            var customers = await _customerRepository.GetAll();
            
            GetAllCustomersDTO customersDTO = new GetAllCustomersDTO();
            foreach(var customer in customers)
            {
                CustomerDogsDTO data = new CustomerDogsDTO();
                data = mapper.CustomerToCustomerDogsDTO(customer);
               customersDTO.customers.Add(data);
            }

            return customersDTO;
        }

        public async Task<CustomerDTO> UpdateCustomer(UpdateCustomerCommand command)
        {
            var customer = await _customerRepository.GetCustomerById(command.id);

            if(customer != null)
            {
                var customerEntity = mapper.CustomerDTOtoCustomer(command.customerToUpdate);
                customerEntity.Id = command.id;
                this._customerRepository.UpdateCustomer(customerEntity);
                return command.customerToUpdate;
            }
            return new CustomerDTO();
          
        }

        public async Task<CustomerDTO> GetCustomerById(string id)
        {
          var customerEntity = await _customerRepository.GetCustomerById(id);

            var customerDTO = mapper.CustomerToCustomerDTO(customerEntity);            
            return customerDTO;
        }

        public async Task<CustomerDogsDTO> GetAllCustomerDataById(string id)
        {
            var customerEntity = await _customerRepository.GetAllCustomerDataById(id);

            var customerDTO = mapper.CustomerToCustomerDogsDTO(customerEntity);
            return customerDTO;
        }
    }
}
