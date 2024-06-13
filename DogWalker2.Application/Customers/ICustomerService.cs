using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Customers.Queries.GetById;
using DogWalker2.Application.Customers.Commands.CreateCommands;
using DogWalker2.Domain;
using DogWalker2.Application.Customers.Commands.UpdateCommands;
using DogWalker2.Application.Customers.Queries.GetAllCustomerDataById;

namespace DogWalker2.Application.Customers
{
    public interface ICustomerService
    {
        void addCustomer(string id);

        Task<CustomerDTO> addCustomerData(CreateCustomerCommand command);

        Task<CustomerDTO> UpdateCustomer(UpdateCustomerCommand command);

        Task deleteCustomer(string id);
    
        Task<GetAllCustomersDTO> GetAll();

        Task<CustomerDTO> GetCustomerById(string id);

        Task<CustomerDogsDTO> GetAllCustomerDataById(string id);


    }
}
