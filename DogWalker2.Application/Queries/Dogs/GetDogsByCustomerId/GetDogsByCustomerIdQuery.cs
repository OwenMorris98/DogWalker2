using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.DTOs.Dogs;
using MediatR;

namespace DogWalker2.Application.Queries.Dogs.GetDogsByCustomerId
{
    public record GetDogsByCustomerIdQuery(string customerId) : IRequest<GetDogsByCustomerIdResponse>;

}
