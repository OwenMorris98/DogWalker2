﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Customers;
using DogWalker2.Api.Customers.DTOs;
namespace DogWalker2.Application.Customers.Commands.CreateCommands
{
    public class CreateCustomerCommand : IRequest
    {

        public string id { get; set; }
        public string first_name { get; set; }

        public string last_name { get; set; }
        public CreateCustomerCommand(AddCustomerDTO cust)
        {
            id = Guid.NewGuid().ToString();
            first_name = cust.first_name;
            last_name = cust.last_name;

        }


    }
}
