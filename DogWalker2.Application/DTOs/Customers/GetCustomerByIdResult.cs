using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Customers
{
    public record GetCustomerByIdResult(string? first_name, string? last_name);
    
}
