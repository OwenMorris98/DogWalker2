using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Application.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.Commands.UpdateCommands
{

    public record UpdateCustomerCommand(string id, CustomerDTO customerToUpdate) : IRequest<CustomerDTO>;
    //public class UpdateCustomerCommand : IRequest
    //{
    //    public string id { get; set; }
    //    public string? first_name { get; set; }

    //    public string? last_name { get; set; }

    //    public string? address { get; set; }

    //    public string? city { get; set; }

    //    public string? state { get; set; }

    //    public string? zipcode { get; set; }

    //    public UpdateCustomerCommand(string id, UpdateCustomerDTO customerToUpdate)
    //    {
    //        this.id = id;
    //        this.first_name = customerToUpdate.first_name;
    //        this.last_name = customerToUpdate.last_name;
    //        this.address =  customerToUpdate.address;
    //        this.city =     customerToUpdate.city;
    //        this.state =    customerToUpdate.state;
    //        this.zipcode =  customerToUpdate.zipcode;
     //   }
    //}
}
