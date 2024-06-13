using DogWalker2.Application.Customers.DTOs;
using DogWalker2.Domain;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Mapperly
{
    [Mapper]
    public partial class CustomerMapper
    {
        
        public partial CustomerDTO CustomerToCustomerDTO(Customer customer);

        public partial CustomerDTO CustomerDTOtoCustomerDTO(CustomerDTO customerDTO);

        public partial Customer CustomerDTOtoCustomer(CustomerDTO customerDTO);

        public partial CustomerDogsDTO CustomerToCustomerDogsDTO(Customer customer);

        public partial GetAllCustomersDTO CustomerListToCustomersDTO(ICollection<Customer> customers);
    }
}
