﻿using DogWalker2.Domain.Walks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Domain.Services
{
    public interface IEmailSender<TUser> where TUser : class
    {
        /// <summary>
        /// This API supports the ASP.NET Core Identity infrastructure and is not intended to be used as a general purpose
        /// email abstraction. It should be implemented by the application so the Identity infrastructure can send confirmation emails.
        /// </summary>
        /// <param name="user">The user that is attempting to confirm their email.</param>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="confirmationLink">The link to follow to confirm a user's email. Do not double encode this.</param>
        /// <returns></returns>
        Task SendConfirmationLinkAsync(TUser user, string email, string confirmationLink);

        /// <summary>
        /// This API supports the ASP.NET Core Identity infrastructure and is not intended to be used as a general purpose
        /// email abstraction. It should be implemented by the application so the Identity infrastructure can send password reset emails.
        /// </summary>
        /// <param name="user">The user that is attempting to reset their password.</param>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="resetLink">The link to follow to reset the user password. Do not double encode this.</param>
        /// <returns></returns>
        Task SendPasswordResetLinkAsync(TUser user, string email, string resetLink);

        /// <summary>
        /// This API supports the ASP.NET Core Identity infrastructure and is not intended to be used as a general purpose
        /// email abstraction. It should be implemented by the application so the Identity infrastructure can send password reset emails.
        /// </summary>
        /// <param name="user">The user that is attempting to reset their password.</param>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="resetCode">The code to use to reset the user password. Do not double encode this.</param>
        /// <returns></returns>
        Task SendPasswordResetCodeAsync(TUser user, string email, string resetCode);

        /// <summary>
        /// This API supports the ASP.NET Core Identity infrastructure and is not intended to be used as a general purpose
        /// email abstraction. It should be implemented by the application so the Identity infrastructure can send password reset emails.
        /// </summary>
        /// <param name="user">The user that is attempting to reset their password.</param>
        /// <param name="email">The recipient's email address.</param>
        
        /// <returns></returns>
        Task SendWalkScheduledAsync(TUser user, Walk walk);
    }
}