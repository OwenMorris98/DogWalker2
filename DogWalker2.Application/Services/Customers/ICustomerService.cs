using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Queries.Customers.GetById;
using DogWalker2.Domain;
using DogWalker2.Application.Queries.Customers.GetAllCustomerDataById;
using DogWalker2.Application.DTOs.Walks;
using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Commands.Customers.UpdateCommands;
using DogWalker2.Application.Commands.Customers.CreateCommands;
using DogWalker2.Application.Commands.Walks;

namespace DogWalker2.Application.Services.Customers
{
    public interface ICustomerService
    {
        void addCustomer(string id);

        //Task<CustomerDTO> addCustomerData(CreateCustomerCommand command);

        Task<CustomerDTO> UpdateCustomer(UpdateCustomerCommand command);

        Task deleteCustomer(string id);

        Task<GetAllCustomersDTO> GetAll();

        Task<CustomerDTO> GetCustomerById(string id);

        Task<CustomerDogsDTO> GetAllCustomerDataById(string id);

        //Task<WalkDTO> ScheduleWalk(ScheduleWalkCommand command);


    }
}
