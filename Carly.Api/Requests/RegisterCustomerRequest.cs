namespace Carly.Api.Requests
{
    public sealed record RegisterCustomerRequest(string Email, string Name, string Password);
}
