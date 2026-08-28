namespace SchoolProject.Service.Abstract
{
    public interface IAuthorizationService
    {
        Task<string> AddRoleAsync(string roleName);
        Task<bool> IsRoleExistByName(string roleName);
        Task<string> EditRoleAsync(string id, string newRoleName);
    }
}
