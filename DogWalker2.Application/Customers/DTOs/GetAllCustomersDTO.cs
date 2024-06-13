using DogWalker2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Customers.DTOs
{
    public class GetAllCustomersDTO
    {
        public ICollection<CustomerDogsDTO> customers { get; set; } = new List<CustomerDogsDTO>();
    }
}
