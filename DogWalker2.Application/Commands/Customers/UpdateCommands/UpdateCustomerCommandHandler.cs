using DogWalker2.Infrastructure.UnitOfWork;
using DogWalker2.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.Services.Customers;

namespace DogWalker2.Application.Commands.Customers.UpdateCommands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerService _customerService;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _customerService.UpdateCustomer(request);
            await _unitOfWork.SaveAsync();

            return response;
        }




    }
}
