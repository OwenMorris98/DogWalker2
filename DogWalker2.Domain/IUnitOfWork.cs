using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();

        Task SaveAsync();
    }
}
