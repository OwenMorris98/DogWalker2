using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Dogs;

namespace DogWalker2.Application.Dogs
{
    public class DogService : IDogService
    {

        private readonly IDogRepository _dogRepository;
        public DogService(IDogRepository dogRepository) 
        { 
            _dogRepository = dogRepository;
        }

        public Task<bool> AddDogAsync(Dog dog)
        {
            return this._dogRepository.AddDogAsync(dog);
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
