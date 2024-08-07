using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetById(int id);

        public Task<T> GetByStringId(string id);

        public Task<IEnumerable<T>> GetAll();

        public void Add(T obj);

        public void Update(T obj);

        public void Remove(T obj);

        public Task SaveAsync();


    }
}
