using Microsoft.AspNetCore.Authorization;

namespace SchoolProject.Core.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission;

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
