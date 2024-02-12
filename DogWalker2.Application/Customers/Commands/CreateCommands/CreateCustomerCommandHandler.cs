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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer cust = new Customer()
            {
                Id = request.id,
                first_name = request.first_name,
                last_name = request.last_name
            };
            _customerService.addCustomerData(cust);
            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
