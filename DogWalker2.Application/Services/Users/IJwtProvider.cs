using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Domain;

namespace DogWalker2.Application.Services.Users
{
    public interface IJwtProvider
    {
        string Generate(Customer user);
    }
}
