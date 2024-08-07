using DogWalker2.Application.Data;
using DogWalker2.Application.DTOs.Customers;
using DogWalker2.Application.Services.Users;
using DogWalker2.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Application.Commands.Users
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserLoginResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IApplicationDbContext context, IJwtProvider jwtProvider)
        {
            _context = context;
            _jwtProvider = jwtProvider;
        }                                     
                                     
        public async Task<UserLoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Customers.FirstOrDefaultAsync(u => u.email == request.email && u.passwordHash == request.password);

            if (user == null)
            {
                return new UserLoginResponse("invalid");
            }
            string token = _jwtProvider.Generate(user);
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == user.Id);
            return new UserLoginResponse(token);
        }
    }
}
