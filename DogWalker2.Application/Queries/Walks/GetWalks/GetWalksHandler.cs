using DogWalker2.Application.Data;
using DogWalker2.Application.DTOs.Walks;
using DogWalker2.Application.Mapperly;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Walks.GetWalks
{
    public class GetWalksHandler : IRequestHandler<GetWalksQuery, List<GetWalksResponseDTO>>
    {
        private readonly IApplicationDbContext _context;

        private WalkMapper _mapper = new WalkMapper();

        public GetWalksHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetWalksResponseDTO>> Handle(GetWalksQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.customerId);

            var walks = await _context.Walks               
                .Include(w => w.Walker)
                .Include(d => d.Dog)
                .ThenInclude(c => c.Customer)
                .Where(w => w.Dog.Customer.Id == request.customerId)
                .AsNoTracking()
                .ToListAsync();

            List<GetWalksResponseDTO> walkResponse = new List<GetWalksResponseDTO>();

            foreach (var walk in walks)
            {
                
                var walkDTO = new GetWalksResponseDTO(
                    walk.WalkID, 
                    walk.Dog.Id,
                    walk.Dog.Name,
                    walk.Walker.WalkerID,
                    walk.Walker.Name,walk.
                    ScheduledTime,
                    walk.Duration,
                    walk.Address,
                    walk.Status,
                    walk.Notes
                    );

                walkResponse.Add(walkDTO);
            }
            return walkResponse;


        }
    }
}
