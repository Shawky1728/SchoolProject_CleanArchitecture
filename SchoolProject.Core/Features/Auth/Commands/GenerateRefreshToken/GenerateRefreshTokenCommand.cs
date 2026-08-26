using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Auth.Commands.GenerateRefreshToken
{
    public class GenerateRefreshTokenCommand : IRequest<Response<GenerateRefreshTokenResponse>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
