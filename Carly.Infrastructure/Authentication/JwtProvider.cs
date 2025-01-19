using Carly.Shared.Abstractions.Authentication;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Carly.Infrastructure.Authentication
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly HttpClient _httpClient;
        private readonly FirebaseOptions _options;

        public JwtProvider(HttpClient httpClient, FirebaseOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<string> GetForCredentialsAsync(string email, string password)
        {
            var request = new
            {
                email,
                password,
                returnSecureToken = true,
            };
            
            var response = await _httpClient.PostAsJsonAsync($"v1/accounts:signInWithPassword?key={_options.ApiKey}", request);

            var result = await response.Content.ReadFromJsonAsync<AuthToken>();

            return result.IdToken;
        }
    }

    public class AuthToken
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
        [JsonPropertyName("localId")]
        public string LocalId { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("idToken")]
        public string IdToken { get; set; }
        [JsonPropertyName("registered")]
        public bool Registered { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }
    }

}
