using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain;

namespace DogWalker2.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Dog> Dogs { get; set; }

        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync();

        int Save();
    }
}
