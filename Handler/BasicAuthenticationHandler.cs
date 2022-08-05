using System.Security.Claims;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
// using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System;
using Microsoft.AspNetCore.Http;

namespace TodoApi.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header was not found.");
            }
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes)?.Split(":");
            string email = credentials[0];
            string password = credentials[1];
            if (email.ToLower() == "prakash.besra@gmail.com" && password == "MyPassword")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, email) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            Console.WriteLine(credentials);
            return AuthenticateResult.Fail("Need to implement");
        }
    }
}