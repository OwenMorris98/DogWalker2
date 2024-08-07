using DogWalker2.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DogWalker2.Api.OptionsSetup
{
    public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<JwtBearerOptionsSetup> _logger;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions, ILogger<JwtBearerOptionsSetup> logger)
        {
            _jwtOptions = jwtOptions.Value;
            _logger = logger;
        }

        public void Configure(JwtBearerOptions options)
        {

        }
        public void Configure(string name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
            };
        }
    }
}
