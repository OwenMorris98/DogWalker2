
using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain.Customers;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Commands.CreateCommands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        async Task<CustomerDTO> IRequestHandler<CreateCustomerCommand, CustomerDTO>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToAdd = await _customerService.addCustomerData(request);
            await _unitOfWork.SaveAsync();
            return customerToAdd;
        }
    }
}
