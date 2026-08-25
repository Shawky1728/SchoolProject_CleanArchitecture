using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest<Response<bool>>
    {

        public string userId { get; set; }
        public string oldPassword { get; set; } = string.Empty;
        public string newPassword { get; set; }

    }
}
