using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Data;
using DogWalker2.Data;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Domain;
using DogWalker2.Domain.Walks;


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

        public async Task<Walker> GetWalkerById(int id)
        {
            var walker = await _context.Walkers.FindAsync(id);
            return walker;
        }

        public async Task<Customer> GetOwner(string id)
        {
            var owner = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            return owner;
        }

        //public async Task<Location> GetWalkLocation(int id)
        //{
        //    var location = await _context.Locations.FindAsync(id);
        //    return location;
        //}

        //public async Task<Location>? IsLocation(string address)
        //{
        //    var loc = await _context.Locations.FirstOrDefaultAsync(l => l.Address == address);
        //    return loc;
        //}

        //public async Task<Location> AddLocation(Location location)
        //{
        //    _context.Locations.Add(location);
        //    await _context.SaveChangesAsync();
        //    return location;
        //}

        public void AddWalk(Walk walk)
        {
            _context.Walks.Add(walk);
        }
    }
}
