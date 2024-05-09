using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Dogs.Commands.CreateCommands;
using DogWalker2.Application.Dogs.DTOs;
using DogWalker2.Domain.Dogs;

namespace DogWalker2.Application.Dogs
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetDogs();

        Task<Dog> GetDogById(string id);

        Task<IEnumerable<Dog>> GetDogsByCustomerId(string customerId);

        Task<DogDTO> AddDogAsync(CreateDogCommand dog);
        bool AddDog(Dog dog);
        bool RemoveDog(Dog dog);
        bool UpdateDog(Dog dog);

     
    }
}
