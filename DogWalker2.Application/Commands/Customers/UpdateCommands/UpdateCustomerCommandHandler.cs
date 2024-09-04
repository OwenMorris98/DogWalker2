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
using DogWalker2.Domain.Repositories;

namespace DogWalker2.Application.Commands.Customers.UpdateCommands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {
        private readonly IRepository<Customer> _repo;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IRepository<Customer> customerRepo, IUnitOfWork unitOfWork)
        {
            _repo = customerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToEdit = await _repo.GetByStringId(request.id);

            if (customerToEdit == null)
            {
                throw new Exception("Customer not found");
            }
            customerToEdit.first_name = request.firstName;
            customerToEdit.last_name = request.lastName;

            await _repo.SaveAsync();

            var response = new UpdateCustomerResult(customerToEdit.Id, customerToEdit.first_name, customerToEdit.last_name);

            return response;
        }




    }
}
