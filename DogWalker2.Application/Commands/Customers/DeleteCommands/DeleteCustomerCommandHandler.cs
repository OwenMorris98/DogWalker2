using DogWalker2.Application.Services.Customers;
using DogWalker2.Domain;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Commands.Customers.DeleteCommands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerService _customerRepo;

        private readonly IUnitOfWork _unitOfWork;

        public string id { get; set; }

        public DeleteCustomerCommandHandler(ICustomerService customerRepo, IUnitOfWork unitOfWork)
        {
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;

        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepo.deleteCustomer(request.id);
            await _unitOfWork.SaveAsync();

        }
    }
}
