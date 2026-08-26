using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<Response<SignInCommandResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
