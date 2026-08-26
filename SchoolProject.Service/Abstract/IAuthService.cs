using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Abstract
{
    public interface IAuthService
    {
        (string token, int ExpiresIn) GenerateTokenAsync(User user);
        string? ValidateToken(string token);
    }
}
