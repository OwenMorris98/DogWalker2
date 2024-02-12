using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Dogs;

namespace DogWalker2.Application.Dogs
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetDogs();

        Task<Dog> GetDogById(string id);

        Task<IEnumerable<Dog>> GetDogsByCustomerId(string customerId);

        Task<bool> AddDogAsync(Dog dog);
        bool AddDog(Dog dog);
        bool RemoveDog(Dog dog);
        bool UpdateDog(Dog dog);

     
    }
}
