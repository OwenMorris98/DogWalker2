using DogWalker2.Application.Data;
using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.DTOs.Walks;
using DogWalker2.Application.Queries.Customers.GetAllCustomerDataById;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Queries.Walks.GetPendingWalks
{
    public class GetPendingWalksQueryHandler : IRequestHandler<GetPendingWalksQuery, IEnumerable<GetPendingWalksQueryResult>>
    {
        private readonly IApplicationDbContext _context;

        public GetPendingWalksQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetPendingWalksQueryResult>> Handle(GetPendingWalksQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            var walks = await _context.Walks
                .Include(c => c.Dog)
                .Include(w => w.Walker)
                .Where(w => w.Dog.customer_id == customer.Id)
                .ToListAsync();

            if (walks == null)
            {
                throw new Exception("No walks found");
            }

            return walks.Select(w => new GetPendingWalksQueryResult(w.Dog.customer_id,
                w.WalkID,
                w.Dog.Id,
                w.Dog.Name,
                w.Walker.WalkerID,
                w.Walker.Name,
                w.ScheduledTime,
                w.Duration,
                w.Address,
                w.Status,
                w.Notes
                )).OrderBy(d => d.scheduledTime);
        }
    }
}
