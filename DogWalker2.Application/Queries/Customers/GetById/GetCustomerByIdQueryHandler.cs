using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.Services.Customers;
using DogWalker2.Domain;
using DogWalker2.Domain.Repositories;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Customers.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByStringId(request.id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            var result = new GetCustomerByIdResult(customer.first_name, customer.last_name);

            return result;
        }
    }
}
