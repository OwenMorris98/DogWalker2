using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.Services.Customers;
using DogWalker2.Domain;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Customers.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly ICustomerService _customerRepo;

        public GetCustomerByIdQueryHandler(ICustomerService customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepo.GetCustomerById(request.id);
        }
    }
}
