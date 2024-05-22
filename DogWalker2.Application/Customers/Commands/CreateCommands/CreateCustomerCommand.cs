using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Customers;
using DogWalker2.Application.Customers.DTOs;
namespace DogWalker2.Application.Customers.Commands.CreateCommands
{

    public record CreateCustomerCommand(CustomerDTO customer) : IRequest<CustomerDTO>;
   
}
