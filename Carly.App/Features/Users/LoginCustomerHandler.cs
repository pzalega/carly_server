using Carly.Shared.Abstractions.Authentication;
using MediatR;

namespace Carly.App.Features.Users
{
    internal sealed class LoginCustomerHandler : IRequestHandler<LoginCustomerCommand>
    {
        private readonly IJwtProvider _jwtProvider;

        public LoginCustomerHandler(IJwtProvider jwtProvider, IHttpClientFactory factory)
        {
            _jwtProvider = jwtProvider;
        }

        public async Task Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
        {
            var token = await _jwtProvider.GetForCredentialsAsync(request.Email, request.Password);
        }
    }
}