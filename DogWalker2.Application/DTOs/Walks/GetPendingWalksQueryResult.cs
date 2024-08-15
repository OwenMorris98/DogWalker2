using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Walks
{
    public record GetPendingWalksQueryResult(
        string customerId,
       int walkId,
       string dogId,
       string DogName,
       int WalkerID,
       string walkerName,
       DateTime scheduledTime,
       int duration,
       string address,
       string status,
       string? notes
       );
}
