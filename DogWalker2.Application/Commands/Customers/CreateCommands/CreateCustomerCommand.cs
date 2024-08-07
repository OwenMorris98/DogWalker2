using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain;
using DogWalker2.Application.DTOs.Customers;
namespace DogWalker2.Application.Commands.Customers.CreateCommands
{

    public record CreateCustomerCommand(string email, string password) : IRequest<CustomerDTO>;

}
