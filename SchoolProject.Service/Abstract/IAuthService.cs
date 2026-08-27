using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Abstract
{
    public interface IAuthService
    {
        (string token, int ExpiresIn) GenerateTokenAsync(User user, IEnumerable<string> roles);
        string? ValidateToken(string token);
    }
}
