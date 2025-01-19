using Carly.Shared.Abstractions.Authentication;
using FirebaseAdmin.Auth;
using System.Net.Http.Json;

namespace Carly.Infrastructure.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientFactory _factory;
        private readonly FirebaseOptions _options;

        public AuthenticationService(IHttpClientFactory factory, FirebaseOptions options)
        {
            _factory = factory;
            _options = options;
        }

        public async Task<string> RegisterAsync(string Email, string Password)
        {
            //TODO handle cases where there is no user or something
            var userArgs = new UserRecordArgs
            {
                Email = Email,
                Password = Password,
            };

            var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            return userRecord.Uid;
        }

        public async Task SendConfirmationEmail(string idToken)
        {
            //TODO handle errors
            using (var client = _factory.CreateClient())
            {
                client.BaseAddress = new Uri("https://identitytoolkit.googleapis.com");

                var requestBody = new
                {
                    requestType = "VERIFY_EMAIL",
                    idToken,
                    
                };
                var result = await client.PostAsJsonAsync($"v1/accounts:sendOobCode?key={_options.ApiKey}", requestBody);
            }
        }
    }
}
