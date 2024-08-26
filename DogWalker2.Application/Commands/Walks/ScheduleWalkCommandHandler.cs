using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Data;
using DogWalker2.Domain;
using DogWalker2.Domain.Walks;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using DogWalker2.Application.Mapperly;
using DogWalker2.Application.DTOs.Walks;
using DogWalker2.Domain.Services;

namespace DogWalker2.Application.Commands.Walks
{
    public class ScheduleWalkCommandHandler : IRequestHandler<ScheduleWalkCommand, ScheduleWalkResponse>
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDogRepository _dogRepository;
        private WalkMapper walkMapper = new WalkMapper();
        private readonly IEmailSender<Customer> _emailSender;
        public ScheduleWalkCommandHandler(IDogRepository dogRepository, IUnitOfWork unitOfWork, IEmailSender<Customer> sender)
        {
            _dogRepository = dogRepository;
            _unitOfWork = unitOfWork;
           _emailSender = sender;
        }

        public async Task<ScheduleWalkResponse> Handle(ScheduleWalkCommand command, CancellationToken cancellationToken)
        {
            var walker = new Walker();

            if (command.request.WalkerID is not null)
            {
                walker = await _dogRepository.GetWalkerById(command.request.WalkerID.Value);
            }
            var dog = await _dogRepository.GetDogById(command.request.DogID);
            var customer = await _dogRepository.GetOwner(dog.customer_id);

            var walk = new Walk()
            {
                Dog = dog,
                Walker = walker,
                ScheduledTime = command.request.ScheduledTime,
                Duration = command.request.Duration,
                Status = command.request.Status,
                Notes = command.request.Notes,
                Address = command.request.Address
            };

            
            
           
            //var walkEntity = walkMapper.WalkDTOtoWalk(walk);
            _dogRepository.AddWalk(walk);           
            await _unitOfWork.SaveAsync();
            await walk.SendScheduledEmail(_emailSender, customer, walk);

            var dogResponse = new ScheduleWalkDog(dog.Id, dog.Name, dog.Breed, dog.Age, dog.Notes);
            ScheduleWalkResponse response = new ScheduleWalkResponse(walk.WalkID, dogResponse, walk.Address, walk.ScheduledTime, walk.Duration, walk.Notes);

            return response;
        }
    }
}
