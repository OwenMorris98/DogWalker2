using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker2.Infrastructure.OptionsSetup
{
    public class AuthMessageSenderOptions
    {
        public string? SendGridKey { get; set; } = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
    }
}
