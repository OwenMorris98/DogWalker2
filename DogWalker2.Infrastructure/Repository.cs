using DogWalker2.Application.Data;
using DogWalker2.Domain.Repositories;
using DogWalker2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByStringId(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
