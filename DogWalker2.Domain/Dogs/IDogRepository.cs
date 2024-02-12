using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain.Dogs;

namespace DogWalker2.Domain.Dogs
{
    public interface IDogRepository
    {
        Task<IEnumerable<Dog>> GetDogs();
        Task<bool> AddDogAsync(Dog dog);
        bool AddDog(Dog dog);
        bool RemoveDog(Dog dog);
        bool UpdateDog(Dog dog);
        Task<Dog> GetDogById(string id);
        Task<IEnumerable<Dog>> GetDogsByCustomerId(string customerId);

    }
}
