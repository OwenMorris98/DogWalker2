using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Queries.GetById
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
