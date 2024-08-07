using DogWalker2.Application.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Commands.Users
{
   public record LoginCommand(string email, string password) : IRequest<UserLoginResponse                 >;
}
