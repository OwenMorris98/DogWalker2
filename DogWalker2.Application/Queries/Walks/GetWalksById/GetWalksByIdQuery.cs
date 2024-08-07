using DogWalker2.Application.DTOs.Dogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Walks.GetWalksById
{
    public record class GetWalksByIdQuery(int id) : IRequest<WalkDTO>;
}
