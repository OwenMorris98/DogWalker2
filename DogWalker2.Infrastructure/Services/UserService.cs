using DogWalker2.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DogWalker2.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticationStateProvider _AuthenticationStateProvider;
        public UserService(AuthenticationStateProvider AuthenticationStateProvider, UserManager<ApplicationUser> userManager) 
        { 
         _userManager = userManager;
         _AuthenticationStateProvider = AuthenticationStateProvider;
        }
        public async Task<string> GetUserId()
        {
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var userIdentity = await _userManager.GetUserAsync(user);
                string userId = userIdentity?.Id;
                return userId;
            }
            return string.Empty;
        }
            
    }
}
