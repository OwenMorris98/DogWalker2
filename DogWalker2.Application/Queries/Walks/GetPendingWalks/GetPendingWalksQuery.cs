using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.DTOs.Walks;
namespace DogWalker2.Application.Queries.Walks.GetPendingWalks
{
    public record GetPendingWalksQuery(string CustomerId) : IRequest<IEnumerable<GetPendingWalksQueryResult>>;
}
