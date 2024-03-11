using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Queries.GetAllCustomers
{
    public record GetCustomerQuery : IRequest<GetAllCustomersDTO>;
   
}
