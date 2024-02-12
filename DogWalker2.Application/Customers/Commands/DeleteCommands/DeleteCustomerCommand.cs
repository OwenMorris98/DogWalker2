using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Commands.DeleteCommands
{
    public class DeleteCustomerCommand : IRequest
    {
        public string id { get; set; }
        public DeleteCustomerCommand(string id)
        {
            this.id = id;
        }

    }
}
