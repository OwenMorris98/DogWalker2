using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Application.Data;
using DogWalker2.Data;
using DogWalker2.Domain;
using DogWalker2.Domain.Walks;

namespace DogWalker2.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
        
    {

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Walker> Walkers { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public int Save()
        {
            return base.SaveChanges();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }


    




    }
}
