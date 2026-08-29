using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.AuthentecationService.Interface
{
    public interface ICurrentUserService
    {
        string GetUserId();
        Task<User> GetUserAsync();
    }
}
