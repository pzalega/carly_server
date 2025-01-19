namespace Carly.Shared.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Task<string> GetForCredentialsAsync(string email, string password);
    }
}
