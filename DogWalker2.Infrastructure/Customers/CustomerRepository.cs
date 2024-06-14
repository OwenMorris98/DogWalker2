using DogWalker2.Application;
using DogWalker2.Application.Data;
using DogWalker2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogWalker2.Domain;

namespace DogWalker2.Infrastructure.Customers
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IApplicationDbContext _context;
        public CustomerRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void addCustomer(Customer customer) =>
            _context.Customers.Add(customer);


        public void addCustomerData(Customer customer)
            => _context.Customers.Add(customer);

        public void deleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            return await _context.Customers.Include(c => c.Dogs).ToListAsync();
        }

        public async Task<Customer?> GetAllCustomerDataById(string id)
        {

            var customer = await _context.Customers
                 .Include(d => d.Dogs).FirstOrDefaultAsync(c => c.Id == id);

            return customer != null ? customer : null;
        }

        public async Task<Customer?> GetCustomerById(string id)
        {

            var customer = await _context.Customers
                 .Include(d => d.Dogs)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

            return customer != null ? customer : null;

        }


        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Attach(customer);
            _context.Customers.Update(customer);
        }
    }
}
