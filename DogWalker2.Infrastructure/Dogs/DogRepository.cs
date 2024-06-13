using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Data;
using DogWalker2.Application.Dogs;
using DogWalker2.Data;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Domain;

namespace DogWalker2.Infrastructure.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly IApplicationDbContext _context;

        public DogRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddDog(Dog dog)
        {
            try
            {
                 _context.Dogs.Add(dog);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> AddDogAsync(Dog dog)
        {
            try
            {
                await _context.Dogs.AddAsync(dog);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Dog> GetDogById(string id)
        {

            var dog = await _context.Dogs.FindAsync(id);
            return dog;

        }

        public async Task<IEnumerable<Dog>> GetDogs()
        {
            return await _context.Dogs.ToListAsync();
        }

        public async Task<IEnumerable<Dog>> GetDogsByCustomerId(string customerId)
        {
            var dogs = await _context.Dogs.Where(d => d.customer_id == customerId).ToListAsync();
            return dogs;
        }

        public bool RemoveDog(Dog dog)
        {
            try
            {
                _context.Dogs.Remove(dog);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       

        public bool UpdateDog(Dog dog)
        {
            try
            {
                _context.Dogs.Update(dog);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
