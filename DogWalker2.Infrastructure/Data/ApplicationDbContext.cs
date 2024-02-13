using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Application.Data;
using DogWalker2.Domain.Dogs;
using DogWalker2.Domain.Customers;
using DogWalker2.Data;

namespace DogWalker2.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
        
    {

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Customer> Customers { get; set; }

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().HasData(
        //        new Customer
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            first_name = "Owen",
        //            last_name = "Morris",
        //            address = "145 Jamestown Ave",
        //            city = "Kennet Square",
        //            state = "PA",
        //            zipcode = "19348"
        //        },
        //        new Customer
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            first_name = "Riley",
        //            last_name = "Zarko",
        //            address = "9 E New Jersey Ave",
        //            city = "Beach Haven",
        //            state = "NJ",
        //            zipcode = "15051"
        //        }
        //    );
        //}

    }
}
