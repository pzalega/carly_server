namespace Carly.Shared.Abstractions.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(string email, string password);
        Task SendConfirmationEmail(string idToken);
    }
}
