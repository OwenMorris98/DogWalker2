using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Customers;
using DogWalker2.Application.Customers.DTOs;
namespace DogWalker2.Application.Customers.Commands.CreateCommands
{

    public record CreateCustomerCommand(CustomerDTO customer) : IRequest<CustomerDTO>;
    //public class CreateCustomerCommand : IRequest<AddCustomerDTO>
    //{

    //    public string id { get; } = Guid.NewGuid().ToString();  
    //    public string first_name { get; set; }

    //    public string last_name { get; set; }

    //    public string? address { get; set; }

    //    public string? city { get; set; }

    //    public string? state { get; set; }

    //    public string? zipcode { get; set; }

    //}
}
