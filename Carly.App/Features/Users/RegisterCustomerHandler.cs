using Carly.Shared.Abstractions.Authentication;
using MediatR;

namespace Carly.App.Features.Users
{
    internal class RegisterCustomerHandler : IRequestHandler<RegisterCustomerCommand>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtProvider _jwtProvider;

        public RegisterCustomerHandler(IAuthenticationService authenticationService, IJwtProvider jwtProvider)
        {
            _authenticationService = authenticationService;
            _jwtProvider = jwtProvider;
        }

        public async Task Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var identityId = await _authenticationService.RegisterAsync(
                request.Email,
                request.Password);
            
            var token = await _jwtProvider.GetForCredentialsAsync(request.Email, request.Password);

            await _authenticationService.SendConfirmationEmail(token);
        }
    }
}
