using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application;
using DogWalker2.Application.DTOs.Dogs;

namespace DogWalker2.Application.Commands.Dogs.CreateCommands
{
    public record CreateDogCommand(string customerId, string name, string breed, int age, string? notes) : IRequest<CreateDogResult>;
}
