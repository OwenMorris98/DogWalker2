using DogWalker2.Application.Data;
using DogWalker2.Domain;
using DogWalker2.Domain.Users;
using DogWalker2.Domain.Walks;
using Microsoft.EntityFrameworkCore;

namespace DogWalker2.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
        
    {

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Customer> Customers { get; set; }

       // public DbSet<Location> Locations { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Walker> Walkers { get; set; }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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

        protected override void ConfigureConventions(
    ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
        }







    }
}
