
namespace SchoolProject.Core.Features.Auth.Commands.GenerateRefreshToken
{
    public class GenerateRefreshTokenResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
        public RefreshTokenResponse? RefreshToken { get; set; }
    }
    public class RefreshTokenResponse
    {
        public string? Token { get; set; } = string.Empty;
        public DateTime? ExpiresAt { get; set; }
    }
}