using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Services.Dogs;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Commands.Dogs.CreateCommands
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, DogDTO>
    {
        private readonly IDogService _dogService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDogCommandHandler(IDogService dogService, IUnitOfWork unitOfWork)
        {
            _dogService = dogService;
            _unitOfWork = unitOfWork;
        }

        public async Task<DogDTO> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dogToAdd = await _dogService.AddDogAsync(request);
            await _unitOfWork.SaveAsync();
            return dogToAdd;
        }
    }
}
