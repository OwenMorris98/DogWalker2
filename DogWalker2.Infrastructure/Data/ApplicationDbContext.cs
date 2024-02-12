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

    }
}
