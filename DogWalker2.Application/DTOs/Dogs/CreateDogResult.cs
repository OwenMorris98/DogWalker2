using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Dogs
{
    public record CreateDogResult(string id, string name, string breed, int age, string? notes);
    
}
