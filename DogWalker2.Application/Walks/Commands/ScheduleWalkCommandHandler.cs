using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Customers;
using DogWalker2.Application.Dogs.DTOs;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;

namespace DogWalker2.Application.Walks.Commands
{
    public class ScheduleWalkCommandHandler : IRequestHandler<ScheduleWalkCommand, WalkDTO>
    {
        private readonly ICustomerService _walkService;
        private readonly IUnitOfWork _unitOfWork;


        public ScheduleWalkCommandHandler(ICustomerService walkService, IUnitOfWork unitOfWork)
        {
            _walkService = walkService;
            _unitOfWork = unitOfWork;
        }

        public async Task<WalkDTO> Handle(ScheduleWalkCommand request, CancellationToken cancellationToken)
        {
            var walkToSchedule = await _walkService.ScheduleWalk(request);
            await _unitOfWork.SaveAsync();

            return walkToSchedule;
        }
    }
}
