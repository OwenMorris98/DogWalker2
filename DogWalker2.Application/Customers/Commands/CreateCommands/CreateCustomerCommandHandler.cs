
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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, AddCustomerDTO>
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        async Task<AddCustomerDTO> IRequestHandler<CreateCustomerCommand, AddCustomerDTO>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            

            AddCustomerDTO customerToAdd = new AddCustomerDTO()
            {
                Id = request.id,
                first_name = request.first_name,
                last_name = request.last_name,
                address = request.address,
                city = request.city,
                state = request.state,
                zipcode = request.zipcode
            };
            _customerService.addCustomerData(customerToAdd);
            _unitOfWork.Save();

            return customerToAdd;
        }
    }
}
