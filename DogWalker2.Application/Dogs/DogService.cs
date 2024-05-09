using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Dogs.Commands.CreateCommands;
using DogWalker2.Application.Dogs.DTOs;
using DogWalker2.Application.Mapperly;
using DogWalker2.Domain.Dogs;

namespace DogWalker2.Application.Dogs
{
    public class DogService : IDogService
    {

        private readonly IDogRepository _dogRepository;

        private readonly DogMapper _mapper;
        public DogService(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
            _mapper = new DogMapper();
        }

        public async Task<DogDTO> AddDogAsync(CreateDogCommand command)
        {
            var dogToAdd = _mapper.DogDTOtoDog(command.dog);
            dogToAdd.Id = Guid.NewGuid().ToString();
            var response = await this._dogRepository.AddDogAsync(dogToAdd);

            if(response)
            {
                return command.dog;
            }
            return new DogDTO();
        }

        public bool AddDog(Dog dog)
        {
            return this._dogRepository.AddDog(dog);
        }

        public async Task<Dog> GetDogById(string id)
        {
            return await this._dogRepository.GetDogById(id);
        }

        public async Task<IEnumerable<Dog>> GetDogs()
        {
            return await this._dogRepository.GetDogs();
        }

        public async Task<IEnumerable<Dog>> GetDogsByCustomerId(string customerId)
        {
            return await this._dogRepository.GetDogsByCustomerId(customerId);
        }

        public bool RemoveDog(Dog dog)
        {
            return this._dogRepository.RemoveDog(dog);
        }

        public bool UpdateDog(Dog dog)
        {
            return this._dogRepository.UpdateDog(dog);
        }

    }
}
