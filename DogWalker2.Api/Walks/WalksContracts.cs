using DogWalker2.Domain.Walks;
using DogWalker2.Domain;

namespace DogWalker2.Api.Walks
{
   public record GetPendingWalksResponse(
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
