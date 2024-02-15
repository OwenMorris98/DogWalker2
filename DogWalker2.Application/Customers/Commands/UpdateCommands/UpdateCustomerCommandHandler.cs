using DogWalker2.Infrastructure.UnitOfWork;
using DogWalker2.Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers.DTOs;

namespace DogWalker2.Application.Customers.Commands.UpdateCommands
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

            //CustomerDTO response = new CustomerDTO()
            //{
            //    first_name = request.customerToUpdate.first_name,
            //    last_name = request.customerToUpdate.last_name,
            //    address = request.customerToUpdate.address,
            //    city = request.customerToUpdate.city,
            //    state = request.customerToUpdate.state,
            //    zipcode = request.customerToUpdate.zipcode
            //};

            return response;
        }

        

     
    }
}
