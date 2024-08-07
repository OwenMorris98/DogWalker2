using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Domain.Users
{
    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }


        public User Create(string email, string password)
        {
            return new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                Password = password,
                Role = new Role(1, "Customer")
            };
        }

    }
}
