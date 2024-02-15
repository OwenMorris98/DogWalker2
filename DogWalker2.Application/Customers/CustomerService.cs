using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers.Commands.CreateCommands;
using DogWalker2.Application.Customers.Commands.UpdateCommands;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore.Update;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public async Task<CustomerDTO> addCustomerData(CreateCustomerCommand command)
        {
            Customer customer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                first_name = command.customer.first_name,
                last_name = command.customer.last_name,
                address = command.customer.address,
                city = command.customer.city,
                state = command.customer.state, 
                zipcode = command.customer.zipcode,
            };

           
            this._customerRepository.addCustomerData(customer);

            CustomerDTO customerToAdd = new CustomerDTO()
            {
                first_name = customer.first_name,
                last_name = customer.last_name,
                address = customer.address,
                city = customer.city,
                state = customer.state,
                zipcode = customer.zipcode
            };

            return customerToAdd;
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
            var customer = await _customerRepository.GetAll();

            GetAllCustomersDTO customerList = new GetAllCustomersDTO()
            {
                customers = customer
            };

            return customerList;
        }

        public async Task<CustomerDTO> UpdateCustomer(UpdateCustomerCommand command)
        {
            var customer = await _customerRepository.GetCustomerById(command.id);

            if(customer != null)
            {
                customer.first_name = command.customerToUpdate.first_name;
                customer.last_name = command.customerToUpdate.last_name;
                customer.address = command.customerToUpdate.address;
                customer.city = command.customerToUpdate.city;
                customer.state = command.customerToUpdate.state;
                customer.zipcode = command.customerToUpdate.zipcode;

                this._customerRepository.UpdateCustomer(customer);

                var updatedCustomer = new CustomerDTO()
                {
                    first_name = customer.first_name,
                    last_name = customer.last_name,
                    address = customer.address,
                    city = customer.city,
                    state = customer.state,
                    zipcode = customer.zipcode
                };
                return updatedCustomer;
            }
            return new CustomerDTO();
          
        }

        public async Task<CustomerDTO> GetCustomerById(string id)
        {
          var customerEntity = await _customerRepository.GetCustomerById(id);

            CustomerDTO customerDTO = new CustomerDTO()
            {
                //Id = customerEntity.Id,
                first_name = customerEntity.first_name,
                last_name = customerEntity.last_name,
                address = customerEntity.address,
                city = customerEntity.city,
                state = customerEntity.state,
                zipcode = customerEntity.zipcode,
            };
            return customerDTO;
        }
    }
}
