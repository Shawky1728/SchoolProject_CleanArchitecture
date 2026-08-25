namespace SchoolProject.Core.Features.Auth.Commands
{
    public class SignInCommandResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
    }
}
