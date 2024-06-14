using DogWalker2.Application.Dogs.DTOs;
using DogWalker2.Application.Walks.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Walks.Commands
{
   public record ScheduleWalkCommand(ScheduleWalkRequest request) : IRequest<WalkDTO>;
}
