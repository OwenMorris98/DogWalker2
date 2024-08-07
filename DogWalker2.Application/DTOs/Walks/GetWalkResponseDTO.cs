using DogWalker2.Domain.Walks;
using DogWalker2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DogWalker2.Application.DTOs.Walks
{

    public record GetWalksResponseDTO(int walkID, string dogId, string dogName,int walkerId, string walkerName, DateTime scheduledTime, int duration, string address, string status, string notes);
  
}
