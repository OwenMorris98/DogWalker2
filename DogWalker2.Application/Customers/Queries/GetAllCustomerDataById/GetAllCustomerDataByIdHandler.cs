using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Mapperly;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Queries.GetAllCustomerDataById
{
    public class GetAllCustomerDataByIdHandler : IRequestHandler<GetAllCustomerDataByIdQuery, CustomerDogsDTO>
    {
        private readonly ICustomerService _customerService;

       
        public GetAllCustomerDataByIdHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDogsDTO> Handle(GetAllCustomerDataByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerService.GetAllCustomerDataById(request.id);
        }
    }
}
