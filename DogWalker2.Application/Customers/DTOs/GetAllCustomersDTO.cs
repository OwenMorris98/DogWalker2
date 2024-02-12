using DogWalker2.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.DTOs
{
    public class GetAllCustomersDTO
    {
        public ICollection<Customer> customers {get; set;}
    }
}
