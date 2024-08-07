using DogWalker2.Domain.Walks;
using DogWalker2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Walks
{
    public record ScheduleWalkResponse(int id, Dog dog, string address, DateTime time, int duration, string notes );
    
}
