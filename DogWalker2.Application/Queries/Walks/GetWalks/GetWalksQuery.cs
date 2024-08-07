using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.DTOs.Walks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Walks.GetWalks
{
    public record GetWalksQuery(string customerId) : IRequest<List<GetWalksResponseDTO>>;
}
