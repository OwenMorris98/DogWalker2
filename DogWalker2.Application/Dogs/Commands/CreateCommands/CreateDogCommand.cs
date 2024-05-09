using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Dogs.DTOs;

namespace DogWalker2.Application.Dogs.Commands.CreateCommands
{
    public record CreateDogCommand(DogDTO dog) : IRequest<DogDTO>;
}
