using DogWalker2.Application.Data;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Mapperly;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Walks.GetWalksById
{
    public class GetWalksByIdHandler : IRequestHandler<GetWalksByIdQuery, WalkDTO>
    {
        private readonly IApplicationDbContext _context;
        private WalkMapper _mapper = new WalkMapper();

        public GetWalksByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WalkDTO> Handle(GetWalksByIdQuery request, CancellationToken cancellationToken)
        {
            var walk = await _context.Walks.FindAsync(request.id);
            var walkDTO = _mapper.WalktoWalkDTO(walk);
            return walkDTO;
        }
    }
}
