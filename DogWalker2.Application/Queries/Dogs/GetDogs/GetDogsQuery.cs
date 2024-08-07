using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.DTOs.Dogs;
namespace DogWalker2.Application.Queries.Dogs.GetDogs
{
    public record GetDogsQuery : IRequest<IEnumerable<DogDTO>>;

}
