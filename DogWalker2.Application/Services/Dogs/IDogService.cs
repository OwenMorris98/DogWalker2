using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Commands.Dogs.CreateCommands;
using DogWalker2.Application.DTOs.Dogs;
using DogWalker2.Domain;

namespace DogWalker2.Application.Services.Dogs
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetDogs();

        Task<Dog> GetDogById(string id);

        Task<IEnumerable<DogDTO>> GetDogsByCustomerId(string customerId);

        Task<DogDTO> AddDogAsync(CreateDogCommand dog);
        bool AddDog(Dog dog);
        bool RemoveDog(Dog dog);
        bool UpdateDog(Dog dog);


    }
}
