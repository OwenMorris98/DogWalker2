using DogWalker2.Domain.Walks;
using DogWalker2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Walks
{
    public record ScheduleWalkResponse(int id, ScheduleWalkDog dog, string address, DateTime time, int duration, string notes );

    public record ScheduleWalkDog(string id, string name, string breed, int age, string? notes);
    
}
