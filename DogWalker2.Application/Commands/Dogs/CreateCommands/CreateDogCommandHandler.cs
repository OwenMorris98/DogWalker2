using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Application.Services.Dogs;
using DogWalker2.Domain;
using DogWalker2.Domain.Repositories;
using DogWalker2.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Commands.Dogs.CreateCommands
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, CreateDogResult>
    {
        private readonly IRepository<Dog> _repository;
        

        public CreateDogCommandHandler(IRepository<Dog> repository)
        {
            _repository = repository;
            
        }

        public async Task<CreateDogResult> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dog = new Dog().Create(
                request.name,
                request.breed,
                request.age,
                request?.notes,
                request.customerId
                );

            _repository.Add(dog);
            await _repository.SaveAsync();
            var dogResult = new CreateDogResult(dog.Id, dog.Name, dog.Breed, dog.Age, dog?.Notes);
            
            return dogResult;
        }
    }
}
