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
        private readonly ICustomerRepository _customerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepo, IUnitOfWork unitOfWork)
        {
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
           var customerSearch = await _customerRepo.GetCustomerById(request.Id);

            CustomerDTO customer = new CustomerDTO()
            {
                Id = customerSearch.Id,
                first_name = customerSearch.first_name,
                last_name = customerSearch.last_name,
                address = customerSearch.address,
                city = customerSearch.city,
                state = customerSearch.state,
                zipcode = customerSearch.zipcode,
            };

            return customer;
        }
    }
}
