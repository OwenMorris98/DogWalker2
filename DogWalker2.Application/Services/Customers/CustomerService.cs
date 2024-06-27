using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Commands.Customers.CreateCommands;
using DogWalker2.Application.Commands.Customers.UpdateCommands;
using DogWalker2.Application.Commands.Walks;
using DogWalker2.Application.Queries.Customers.GetAllCustomerDataById;
using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Mapperly;
using DogWalker2.Application.DTOs.Walks;
using DogWalker2.Domain;
using DogWalker2.Domain.Walks;
using MediatR;
using Microsoft.EntityFrameworkCore.Update;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DogWalker2.Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDogRepository _dogRepository;

        private CustomerMapper mapper = new CustomerMapper();
        private WalkMapper walkMapper = new WalkMapper();

        public CustomerService(ICustomerRepository customerRepository, IDogRepository dogRepository)
        {
            _customerRepository = customerRepository;
            _dogRepository = dogRepository;
        }

        public void addCustomer(string id)
        {
            Customer cust = new Customer() { Id = id };
            _customerRepository.addCustomer(cust);
        }

        public async Task<CustomerDTO> addCustomerData(CreateCustomerCommand command)
        {
            var customer = mapper.CustomerDTOtoCustomer(command.customer);
            customer.Id = Guid.NewGuid().ToString();
            _customerRepository.addCustomerData(customer);
            return command.customer;
        }

        public async Task deleteCustomer(string id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            _customerRepository.deleteCustomer(customer);
        }

        public async Task<Customer> getCustomerById(string id)
        {

            var customer = await _customerRepository.GetCustomerById(id);
            return customer;
        }


        public async Task<GetAllCustomersDTO> GetAll()
        {
            var customers = await _customerRepository.GetAll();

            GetAllCustomersDTO customersDTO = new GetAllCustomersDTO();
            foreach (var customer in customers)
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

            if (customer != null)
            {
                var customerEntity = mapper.CustomerDTOtoCustomer(command.customerToUpdate);
                customerEntity.Id = command.id;
                _customerRepository.UpdateCustomer(customerEntity);
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

        public async Task<WalkDTO> ScheduleWalk(ScheduleWalkCommand command)
        {
            var walker = new Walker();

            if (command.request.WalkerID is not null)
            {
                walker = await _dogRepository.GetWalkerById(command.request.WalkerID.Value);
            }
            var dog = await _dogRepository.GetDogById(command.request.DogID);

            var walk = new WalkDTO()
            {
                Dog = dog,
                Walker = walker,
                ScheduledTime = command.request.ScheduledTime,
                Duration = command.request.Duration,
                Status = command.request.Status,
                Notes = command.request.Notes
            };

            var locationExists = await _dogRepository.IsLocation(command.request.Address);
            Location location;
            if (locationExists is not null)
            {
                walk.Location = locationExists;

            }
            else
            {

               
               walk.Location = await _dogRepository.AddLocation(new Location()
                {
                    Address = command.request.Address
                });
                
                
            }
            // Set the LocationId for the walk entity
           

            var walkEntity = walkMapper.WalkDTOtoWalk(walk);


            _dogRepository.AddWalk(walkEntity);


            return walk;
        }
    }
}
