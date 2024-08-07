using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Services.Dogs;
using Microsoft.EntityFrameworkCore.Metadata;
using DogWalker2.Application.Mapperly;

namespace DogWalker2.Application.Queries.Dogs.GetDogsByCustomerId
{
    public class GetDogsByCustomerIdHandler : IRequestHandler<GetDogsByCustomerIdQuery, GetDogsByCustomerIdResponse>
    {
        private readonly IDogService _dogService;
        

        public GetDogsByCustomerIdHandler(IDogService dogService)
        {
            _dogService = dogService;
        }

        public Task<GetDogsByCustomerIdResponse> Handle(GetDogsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var dogs = _dogService.GetDogsByCustomerId(request.customerId);
            return dogs;
        }
    }
}
