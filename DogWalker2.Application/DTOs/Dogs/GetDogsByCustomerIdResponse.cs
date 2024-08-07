using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.DTOs.Dogs
{
    public class GetDogsByCustomerIdResponse
    {
        public ICollection<DogDTO> Dogs { get; set; } = new List<DogDTO>();

        public void AddDog(DogDTO dog)
        {
            Dogs.Add(dog);
        }
    }
}
