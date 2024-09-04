using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using DogWalker2.Data;
using Microsoft.Extensions.Logging;
using DogWalker2.Infrastructure.OptionsSetup;
using Microsoft.AspNetCore.Identity.UI.Services;
using DogWalker2.Domain;
using DogWalker2.Domain.Services;
using DogWalker2.Domain.Walks;


namespace DogWalker2.Infrastructure.Services
{
    public class EmailSender : IEmailSender<Customer>
    {
        private readonly ILogger _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; set; } = new();//Set with Secret Manager.

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(Options.SendGridKey, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("opm.dogwalker@gmail.com", "Philly Dogwalker"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }

        public async Task SendConfirmationLinkAsync(Customer user, string email, string confirmationLink)
        {
            await SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
        }

        public async Task SendPasswordResetLinkAsync(Customer user, string email, string resetLink)
        {
            await SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
        }

        public async Task SendPasswordResetCodeAsync(Customer user, string email, string resetCode)
        {
            await SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
        }

        public async Task SendWalkScheduledAsync(Customer user, Walk walk)
        {
            await SendEmailAsync(user.email, @$"You scheduled a walk!", @$"Thank you for scheduling your walk!
                {Environment.NewLine}Details: 
                {Environment.NewLine}Walker: {walk.Walker.Name}
                {Environment.NewLine}Date: {walk.ScheduledTime.Date}
                {Environment.NewLine}Time: {walk.ScheduledTime.TimeOfDay}
                {Environment.NewLine}Address: {walk.Address}
                {Environment.NewLine}Duration: {walk.Duration} minutes");
        }
    }
}
