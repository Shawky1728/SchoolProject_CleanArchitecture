using MediatR;
using SchoolProject.Core.Shared.ReponseHandling;

namespace SchoolProject.Core.Features.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<Response<AddUserResponse>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; } = null;
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
