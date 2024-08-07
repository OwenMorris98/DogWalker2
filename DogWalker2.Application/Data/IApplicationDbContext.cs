using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain;
using DogWalker2.Domain.Walks;
using DogWalker2.Domain.Users;

namespace DogWalker2.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Dog> Dogs { get; set; }

        DbSet<Customer> Customers { get; set; }
        DbSet<Walker> Walkers { get; set; }
        DbSet<Walk> Walks { get; set; }

        //DbSet<Location> Locations { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; } 
        
        Task<int> SaveChangesAsync();

        int Save();

        
    }
}
