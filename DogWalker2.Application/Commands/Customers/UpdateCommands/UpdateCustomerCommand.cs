﻿using DogWalker2.Application.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Commands.Customers.UpdateCommands
{

    public record UpdateCustomerCommand(string id, string firstName, string lastName) : IRequest<UpdateCustomerResult>;

}
