using DogWalker2.Infrastructure.UnitOfWork;
using DogWalker2.Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Commands.UpdateCommands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerService _customerService;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer cust = new Customer()
            {
                Id = request.id,
                first_name = request.first_name,
                last_name = request.last_name,
                address = request.address,
                city    = request.city,
                state = request.state,
                zipcode = request.zipcode,

            };
            _customerService.UpdateCustomer(cust);
            _unitOfWork.Save();
            
        }
    }
}
