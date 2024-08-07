using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Customers.GetAllCustomers
{
    public record GetCustomerQuery : IRequest<GetAllCustomersDTO>;

}
