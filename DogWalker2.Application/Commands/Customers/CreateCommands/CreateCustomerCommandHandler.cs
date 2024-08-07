using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.Mapperly;
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

namespace DogWalker2.Application.Commands.Customers.CreateCommands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomerMapper _mapper;

        public CreateCustomerCommandHandler(IRepository<Customer> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = new CustomerMapper();
        }

        async Task<CustomerDTO> IRequestHandler<CreateCustomerCommand, CustomerDTO>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // var customerToAdd = await _customerService.addCustomerData(request);
            var customerToAdd = new Customer().Create(request.email, request.password);
            _repository.Add(customerToAdd);
            await _repository.SaveAsync();
            var customerDTO = _mapper.CustomerToCustomerDTO(customerToAdd);
            return customerDTO;
        }
    }
}
