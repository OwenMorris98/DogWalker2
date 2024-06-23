using DogWalker2.Application.DTOs.Dogs;
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
    public partial class DogMapper
    {
        public partial DogDTO DogToDogDTO(Dog dog);

        public partial Dog DogDTOtoDog(DogDTO dog);

        public partial IEnumerable<DogDTO> DogsToDogDTOs(IEnumerable<Dog> dogs);
    }
}
