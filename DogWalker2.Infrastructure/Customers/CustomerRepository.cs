using DogWalker2.Application.Customers;
using DogWalker2.Application.Data;
using DogWalker2.Domain.Customers;
using DogWalker2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Customers.ToListAsync(); 

        }

        public async Task<Customer> GetCustomerById(string id)
        {
            try
            {
                return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch(Exception ex)
            {
                string exception = ex.ToString();
                return null;
            }
            
        } 
            

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
