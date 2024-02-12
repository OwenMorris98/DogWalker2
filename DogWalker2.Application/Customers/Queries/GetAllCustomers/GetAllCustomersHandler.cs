using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersHandler : IRequestHandler<GetCustomerQuery, GetAllCustomersDTO>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomersHandler(ICustomerRepository customerService, IUnitOfWork unitOfWork)
        {
            _customerRepo = customerService;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllCustomersDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepo.GetAll();

            GetAllCustomersDTO cust = new GetAllCustomersDTO()
            {
                customers = customers
            };
            return cust;
        }
    }
}
