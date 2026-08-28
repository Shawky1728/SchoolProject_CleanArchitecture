using Microsoft.AspNetCore.Authorization;

namespace SchoolProject.Core.Authorization
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission) : base(permission)
        {
        }
    }
}
