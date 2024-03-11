using DogWalker2.Application.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Queries.GetAllCustomerDataById
{
    public record GetAllCustomerDataByIdQuery(string id) : IRequest<CustomerDogsDTO>;
   
}
